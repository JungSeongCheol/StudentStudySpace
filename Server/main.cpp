#define _CRT_SECURE_NO_WARNINGS
#include <windows.h>
#include <Winsock.h>
#include <iostream>
#include <vector>
#include <sstream>
#include <mutex>

#include "mysql_connection.h"

#include <cppconn/driver.h>
#include <cppconn/exception.h>
#include <cppconn/resultset.h>
#include <cppconn/statement.h>
#include <cppconn/prepared_statement.h>

#pragma comment (lib, "ws2_32.lib")

#pragma comment(lib, "mysqlcppconn.lib")

#pragma region 다른 라이브러리(mysql)
//#pragma comment(lib, "libmySQL.lib")
//#define DB_HOST "localhost"	// DB IP주소 또는 도메인 또는 localhost
//#define DB_USER "root"		// DB접속 계정 명
//#define DB_PASS "mysql_p@ssw0rd"		// DB접속 계정 암호
//#define DB_NAME "gomokuuser"		// DB 이름
#pragma endregion

std::mutex mClient;
std::mutex mRoom;

class Room;
class Client;

int roomNum = 0; // 룸넘버 (0번째, 1번쨰 ...) 방의 번호를 정해줌

class Client {
private:
	std::string clientID;
	std::string where;
	
	int roomID;
	SOCKET clientSocket;
	bool ready;
	Room* myRoom;
	bool player;
public:
	Client(SOCKET clientSocket) {
		this->roomID = -1;
		this->clientSocket = clientSocket;
		where = "WaitingRoom";
	} // 클라이언트 생성시 초기값.

	std::string getClientID() {
		return clientID;
	}

	bool setClientID(std::string client, std::vector<Client*> connections) {
		mClient.lock();
		for (int i = 0; i < connections.size(); i++) {
			if (client == connections[i]->getClientID()) {
				mClient.unlock();	// 중복ID제거 (쿼리시 중복있으면 false 반환을 하기위해)
				return false;
			}
		}
		mClient.unlock();
		this->clientID = client;
		return true;
	}

	int getRoomID() {
		return roomID;
	}
	void setRoomID(int roomID) {
		this->roomID = roomID;
	}
	SOCKET getClientSocket() {
		return clientSocket;
	}
	std::string getWhere() {
		return where;
	}
	void setWhere(std::string where) {
		this->where = where;	//현재 위치를 반환하기위한것인지(대기실인지, 아니면 게임방인지)
	}
	Room* getMyRoom() {
		return this->myRoom;
	}
	void setReady(bool ready) {
		this->ready = ready;
	}
	bool getReady() {
		return this->ready;
	}

	void setMyRoom(Room* room) {
		this->myRoom = room;
	}

	bool getPlayer() {
		return player;
	}

	void setPlayer(bool Player) {
		this->player = Player;
	}
};

class Room {
private:
	std::string roomName;
	std::vector<Client*> people;
	std::vector<Client*> observer;

	int roomID;
	std::vector<std::pair<std::string, std::pair<int, int>>> board;
public:
	Room(std::string roomName, Client* user) {
		people.push_back(user);
		this->roomName = roomName;
		this->roomID = roomNum++;
	}

	std::string getRoomName() {
		return roomName;
	}

	std::vector<Client*> getPeople() {
		return people;
	}

	int getPeopleNum() {
		return people.size();
	}

	std::vector<Client*> getObserver() {
		return observer;
	}

	int getObserverNum() {
		return observer.size();
	}

	void setPeople(std::vector<Client*> people) {
		this->people = people;
	}

	int getRoomID() {
		return roomID;
	}

	bool joinRoom(Client* user) {
		if (people.size() < 2) {
			people.push_back(user);
			user->setPlayer(true);
			return true;
		}
		else {
			observer.push_back(user);
			user->setPlayer(false);
			return true;
		}
		return false;
	}

	void deleteUser(Client* user) {
		if (user->getPlayer() == true) {
			for (int i = 0; i < people.size(); i++) {
				if (people[i]->getClientID() == user->getClientID()) {
					people.erase(people.begin() + i);
					break;
				}
			}
		}
		else {
			for (int i = 0; i < observer.size(); i++) {
				if (observer[i]->getClientID() == user->getClientID()) {
					observer.erase(observer.begin() + i);
					break;
				}
			}
		}
	}

	void setBoard(int x, int y, std::string c) {
		board.push_back(std::make_pair(c, std::make_pair(x, y)));// (c,x,y)를 만듬([Put]c,x,y 이렇게 나타내기위해)
	}
	
	int getBoardSize() {
		return board.size(); // 지금까지둔 모든 돌을 저장하기 위해 사용됨(관전을 위해서)
	}
	std::vector <std::pair<std::string, std::pair<int, int>>> getBoard() { 
		// [Put]시 사용함 ([Put]B(흑돌인지 흰돌인지),10(x좌표),20(y좌표)
		return board;
	}
};

SOCKET serverSocket;
std::vector<Client*> connections;
std::vector<Room*> rooms;

WSAData wsaData;
SOCKADDR_IN serverAddress;
int roomnumber = 0;
int nextID;

std::vector<std::string> getTokens(std::string input, char delimiter) {
	std::vector<std::string> tokens;
	std::istringstream f(input);
	std::string s;
	while (std::getline(f, s, delimiter)) {
		tokens.push_back(s);
	}
	return tokens;
}

int clientCountInRoom(int roomID) {
	int count = 0;
	for (int i = 0; i < connections.size(); i++) {
		if (connections[i]->getRoomID() == roomID) {
			count++;
		}
	}
	return count;
}

void playClient(int roomID) {
	char* sent = new char[256];
	bool black = true;
	for (int i = 0; i < connections.size(); i++) {
		if (connections[i]->getRoomID() == roomID) {
			ZeroMemory(sent, 256);
			if (black) {
				sprintf(sent, "%s", "[Play]Black");
				black = false;
			}
			else {
				sprintf(sent, "%s", "[Play]White");
			}
			send(connections[i]->getClientSocket(), sent, 256, 0);
		}
	}
}

void exitClient(int roomID) {
	char* sent = new char[256];
	for (int i = 0; i < connections.size(); i++) {
		if (connections[i]->getRoomID() == roomID) {
			ZeroMemory(sent, 256);
			sprintf(sent, "%s", "[Exit]");
			send(connections[i]->getClientSocket(), sent, 256, 0);
		}
	}
}

void putClient(Client* client, int x, int y, std::string c) {
	char* sent = new char[256];
	Room* room = client->getMyRoom();
	client->getMyRoom()->setBoard(x, y, c);

	mRoom.lock();
	for (int i = 0; i < room->getPeopleNum(); i++) {
		std::string data = "[Put]" + std::to_string(x) + "," + std::to_string(y);
		send(room->getPeople()[i]->getClientSocket(), data.c_str(), data.length(), 0);
	}

	for (int i = 0; i < room->getObserverNum(); i++) {
		std::string data = "[Put]";
		for (int i = 0; i < room->getBoardSize(); i++) {
			data += room->getBoard()[i].first + "," + std::to_string(room->getBoard()[i].second.first) + "," + std::to_string(room->getBoard()[i].second.second) + ";";
			//옵저버의 숫자만큼 put을 보내줌 ex) [Put]B(블랙인지)or W(화이트인지),1(x좌표),1(y좌표)
		}
		send(room->getObserver()[i]->getClientSocket(), data.c_str(), data.length(), 0);
	}
	mRoom.unlock();
}

void refreshUsers() {
	std::string conn = "[Users]";
	mClient.lock();
	for (int i = 0; i < connections.size(); i++) {
		if (connections[i]->getWhere() == "WaitingRoom") {
			conn.append(connections[i]->getClientID());
			conn.append(",");
		}
	}
	conn.erase(conn.end());

	for (int i = 0; i < connections.size(); i++) {
		send(connections[i]->getClientSocket(), conn.c_str(), conn.length() - 1, 0);
	}
	mClient.unlock();
}

void refreshRooms() {
	mRoom.lock();
	std::string conn = "[PlayingRoom]";
	for (int i = 0; i < rooms.size(); i++) {
		conn.append(std::to_string(rooms[i]->getRoomID()));
		conn.append(",");
		conn.append(rooms[i]->getRoomName());
		conn.append(",");
		conn.append(std::to_string(rooms[i]->getPeopleNum()));
		conn.append(",");
		conn.append(std::to_string(rooms[i]->getObserverNum()));
		conn.append(";");
	}
	mRoom.unlock();

	mClient.lock();
	for (int i = 0; i < connections.size(); i++) {
		if (connections[i]->getWhere() == "WaitingRoom") {
			send(connections[i]->getClientSocket(), conn.c_str(), conn.length(), 0);
		}
	}
	mClient.unlock();
}

void refreshWaitingRooms() {
	std::string conn = "[Refresh]";

	mRoom.lock();
	if (rooms.size() == 0) {
		conn.append("empty;");
	}
	else {
		for (int i = 0; i < rooms.size(); i++) {
			conn.append(std::to_string(rooms[i]->getRoomID()));
			conn.append(",");
			conn.append(rooms[i]->getRoomName());
			conn.append(",");
			conn.append(std::to_string(rooms[i]->getPeopleNum()));
			conn.append(",");
			conn.append(std::to_string(rooms[i]->getObserverNum()));
			conn.append(";");
		}
	}
	conn.append("/");
	mRoom.unlock();

	mClient.lock();
	for (int i = 0; i < connections.size(); i++) {
		if (connections[i]->getWhere() == "WaitingRoom") {		//2020-08-19 변경
			conn.append(connections[i]->getClientID());
			conn.append(",");
		}
	}
	for (int i = 0; i < connections.size(); i++) {
		send(connections[i]->getClientSocket(), conn.c_str(), conn.length() - 1, 0);
	}
	mClient.unlock();
}

const sql::SQLString server = "tcp://127.0.0.1:3306";
const sql::SQLString username = "root";
const sql::SQLString password = "mysql_p@ssw0rd";

void ServerThread(Client* client) {
	char* sent = new char[256];
	char* received = new char[256];
	int size = 0;

	while (true) {
		ZeroMemory(received, 256);
		if ((size = recv(client->getClientSocket(), received, 256, NULL)) > 0) {
			std::string receivedString = std::string(received); // 같은 문자로 만듬
			std::vector<std::string> tokens = getTokens(receivedString, ']');
			sql::Driver* driver;
			sql::Connection* con;
			sql::PreparedStatement* pstmt;
			sql::Statement* stmt;
			sql::ResultSet* result;

			try
			{
				driver = get_driver_instance();
				con = driver->connect(server, username, password);
			}
			catch (std::exception)
			{
				std::cout << "SQL error" << std::endl;
				return;
			}
			con->setSchema("gomokuuser");

			if (receivedString.find("[Login]") != -1){
				std::vector<std::string> dataTokens = getTokens(tokens[1], ',');
				std::string id = dataTokens[0];
				std::string password = dataTokens[1];
				
				pstmt = con->prepareStatement("SELECT * FROM usertbl WHERE User_Id=? AND Password=?");
				pstmt->setString(1, id.c_str());
				pstmt->setString(2, password.c_str());
				result = pstmt->executeQuery();

				if (result->next()) {
					bool login = client->setClientID(id, connections);
					if (login == false) {
						send(client->getClientSocket(), "already", 7, NULL);
					}
					else {
						mClient.lock();
						connections.push_back(client);
						mClient.unlock();

						send(client->getClientSocket(), "OK", 2, NULL);
						break;
					}
				}
				else {
					send(client->getClientSocket(), "invalid", 7, NULL);
				}
			}

			else if (receivedString.find("[SignUp]") != -1) {
				std::vector<std::string> dataTokens = getTokens(tokens[1], ',');
				std::string id = dataTokens[0];
				std::string password = dataTokens[1];

				pstmt = con->prepareStatement("INSERT INTO usertbl(User_Id, PassWord) VALUES (? ,? )");
				pstmt->setString(1, id.c_str());
				pstmt->setString(2, password.c_str());

				try {
					int r = pstmt->executeUpdate();
					send(client->getClientSocket(), "SignUpOk", 8, NULL);
				}
				catch (sql::SQLException e) {
					send(client->getClientSocket(), "SignUpFalse", 11, NULL);
				}
			}
		}
	}

	if (client->getClientID() == "") return;
	std::cout << "[ 새로운 사용자 [" << client->getClientID() << "] 접속 ]" << std::endl;

	while (true) {
		ZeroMemory(received, 256);
		if ((size = recv(client->getClientSocket(), received, 256, NULL)) > 0) {
			std::string receivedString = std::string(received);
			std::vector<std::string> tokens = getTokens(receivedString, ']');

			if (receivedString.find("[WaitingRoom]") != -1) {
				std::vector<std::string> WaitingRoomTokens = getTokens(tokens[1], 0x01);

				if (WaitingRoomTokens[0] == "Refresh") {
					refreshWaitingRooms();
				}

				if (WaitingRoomTokens[0] == "Users") {
					refreshUsers();
				}

				else if (WaitingRoomTokens[0] == "Chats") {
					std::string conn = "[Chat]" + client->getClientID() + ": " + WaitingRoomTokens[1];
					mClient.lock();
					for (int i = 0; i < connections.size(); i++) {
						if (connections[i]->getWhere() == "WaitingRoom")
							send(connections[i]->getClientSocket(), conn.c_str(), conn.length(), 0);
					}
					mClient.unlock();
				}
			}

			else if (receivedString.find("[PlayingRoom]") != -1) {
				std::vector<std::string> roomTokens = getTokens(tokens[1], 0x01);

				if (roomTokens[0] == "Create") {

					Room* room = new Room(roomTokens[1], client);
					rooms.push_back(room);

					client->setWhere("PlayingRoom");
					client->setRoomID(room->getRoomID());
					client->setMyRoom(room);
					client->setPlayer(true);

					refreshUsers();
					Sleep(10);

					std::string conn = "[Create]" + std::to_string(room->getRoomID());
					send(client->getClientSocket(), conn.c_str(), conn.length(), 0);

					Sleep(100);
					send(client->getClientSocket(), " ", 1, 0);
				}

				else if (roomTokens[0] == "Refresh") {
					refreshRooms();
				}

				else if (roomTokens[0] == "Join") {
					std::string msg = "[Join]";
					mRoom.lock();
					for (int i = 0; i < rooms.size(); i++) {
						if (std::to_string(rooms[i]->getRoomID()) == roomTokens[1].c_str()) {
							if (rooms[i]->joinRoom(client)) {
								client->setWhere("PlayingRoom");
								client->setRoomID(rooms[i]->getRoomID());
								client->setMyRoom(rooms[i]);

								refreshUsers();
								Sleep(10);

								if (client->getPlayer() == true) {
									msg += ("success,Player," + std::to_string(rooms[i]->getRoomID()));
								}
								else {
									msg += ("success,Observer," + std::to_string(rooms[i]->getRoomID()));
								}
								send(client->getClientSocket(), msg.c_str(), msg.length(), 0);

								Sleep(100);
								send(client->getClientSocket(), " ", 1, 0);
							}
							else {
								msg.append("fail");
								send(client->getClientSocket(), msg.c_str(), msg.length(), 0);
							}
							break;
						}
					}
					mRoom.unlock();
				}

				else if (roomTokens[0] == "Exit") {
					mRoom.lock();
					for (int i = 0; i < rooms.size(); i++) {
						if (rooms[i]->getRoomID() == client->getRoomID()) {

							client->setWhere("WaitingRoom");
							client->setMyRoom(NULL);
							client->setRoomID(-1);

							rooms[i]->deleteUser(client);

							if (rooms[i]->getPeopleNum() == 0) {
								rooms.erase(rooms.begin() + i);
							} // 방에서 나갔을떄, 클라이언트와 방의 ID가 같은경우, 클라이언트의 위치를 변경, 현재 룸에 들어가지않았다는것을 가르쳐줌
							  // 그후 룸에 Client가 나갔으니 안에있던 클라이언트의 정보를 지우고, 방안에 사람이 한명도 없을경우, 그방을 지운다.
							break;
						}
					}
					mRoom.unlock();
					refreshWaitingRooms();
				}

				else if (roomTokens[0] == "Chats") {
					Room* room = client->getMyRoom();
					std::string conn = "[Chats]" + client->getClientID() + " " + roomTokens[1]; //공백있는 이유 -> 공백을 : 으로 MultiPlay라는 폼에서 Client 아이디를 나타내기위해
					for (int i = 0; i < room->getPeopleNum(); i++) {
						send(room->getPeople()[i]->getClientSocket(), conn.c_str(), conn.length(), 0);
					}
					for (int i = 0; i < room->getObserverNum(); i++) {
						send(room->getObserver()[i]->getClientSocket(), conn.c_str(), conn.length(), 0);
					}
				}

				else if (roomTokens[0] == "Ready") {
					mRoom.lock();
					client->setReady(true);
					Room* myRoom = client->getMyRoom();
					bool readyChk = true;
					if (myRoom->getPeopleNum() == 2) {
						for (int i = 0; i < myRoom->getPeopleNum(); i++) {
							if (myRoom->getPeople()[i]->getReady() == false) { //client의 룸의 vector[i] 레디를 하나라도 안했으면, 실행불가;
								readyChk = false;
								break;
							}
						}
						if (readyChk == true) {
							std::string msg = "[Play]Black";
							send(myRoom->getPeople()[0]->getClientSocket(), msg.c_str(), msg.length(), 0);

							msg = "[Play]White";
							send(myRoom->getPeople()[1]->getClientSocket(), msg.c_str(), msg.length(), 0);
						}
					}
					mRoom.unlock();
				}

				else if (roomTokens[0] == "Invite") {
					std::string conn = "[Invite]";
					mClient.lock();
					for (int i = 0; i < connections.size(); i++) {
						if (connections[i]->getWhere() == "WaitingRoom") {
							conn.append(connections[i]->getClientID());
							conn.append(",");
						}
					}
					conn.erase(conn.end());

					for (int i = 0; i < connections.size(); i++) {
						send(connections[i]->getClientSocket(), conn.c_str(), conn.length() - 1, 0);
					}
					mClient.unlock();
				}

				else if (roomTokens[0] == "InvUser") {
					std::string msg = "[InvUser]";
					std::string FullMessage = roomTokens[1].c_str();
					std::vector<std::string> RoomNumandClient = getTokens(FullMessage, ',');
					msg += RoomNumandClient[0] + "," + client->getClientID() + "," + client->getMyRoom()->getRoomName();
					mRoom.lock();

					for (int i = 0; i < connections.size(); i++)
					{
						if (connections[i]->getClientID() == RoomNumandClient[1].c_str()) {
							send(connections[i]->getClientSocket(), msg.c_str(), msg.length(), 0);
							break;
						}
					}
				mRoom.unlock();
				}
			}

			#pragma region 예전(Mysql을 쓰지않았을때의 tcpClient내용)
			//if (receivedString.find("[Enter]") != -1) {
			//	/* 메시지를 보낸 클라이언트를 찾기 */
			//	for (int i = 0; i < connections.size(); i++) {
			//		std::string roomID = tokens[1];
			//		int roomInt = atoi(roomID.c_str());
			//		if (connections[i]->getClientSocket() == client->getClientSocket()) {
			//			int clientCount = clientCountInRoom(roomInt);
			//			/* 2명 이상이 동일한 방에 들어가 있는 경우 가득 찼다고 전송 */
			//			if (clientCount >= 2) {
			//				ZeroMemory(sent, 256);
			//				sprintf(sent, "%s", "[Full]");
			//				send(connections[i]->getClientSocket(), sent, 256, 0);
			//				break;
			//			}
			//			std::cout << "클라이언트 [" << client->getClientID() << "]: " << roomID << "번 방으로 접속" << std::endl;
			//			/* 해당 사용자의 방 접속 정보 갱신 */
			//			Client* newClient = new Client(*client);
			//			newClient->setRoomID(roomInt);
			//			connections[i] = newClient;
			//			/* 방에 성공적으로 접속했다고 메시지 전송 */
			//			ZeroMemory(sent, 256);
			//			sprintf(sent, "%s", "[Enter]");
			//			send(connections[i]->getClientSocket(), sent, 256, 0);
			//			/* 상대방이 이미 방에 들어가 있는 경우 게임 시작 */
			//			if (clientCount == 1) {
			//				playClient(roomInt);
			//			}
			//		}
			//	}
			//}
			#pragma endregion

			else if (receivedString.find("[Put]") != -1) {
				std::vector<std::string> putTokens = getTokens(tokens[1], ','); //
				int x = atoi(putTokens[0].c_str());
				int y = atoi(putTokens[1].c_str());
				std::string c = putTokens[2].c_str();
				/* 사용자가 놓은 돌의 위치를 전송 */
				putClient(client, x, y, c);
			}

			else if (receivedString.find("[Observer]") != -1) {
				Room* room = client->getMyRoom();
				std::string data = "[Put]";
				for (int i = 0; i < room->getBoardSize(); i++) {
					data += room->getBoard()[i].first + "," + std::to_string(room->getBoard()[i].second.first) + "," + std::to_string(room->getBoard()[i].second.second) + ";";
					//ex) [Put]B(블랙인지)or W(화이트인지),1(x좌표),1(y좌표)
					//마지막 ;는 [Put]W,1,2;B,1,2;처럼 계속 붙였을때 구분하기위해서
				}
				send(client->getClientSocket(), data.c_str(), data.length(), 0);
			}
		}

		else {
			ZeroMemory(sent, 256);
			sprintf(sent, "클라이언트 [%s]의 연결이 끊어졌습니다.", client->getClientID().c_str());
			std::cout << sent << std::endl;
			/* 게임에서 나간 플레이어를 찾기 */
			mClient.lock();
			for (int i = 0; i < connections.size(); i++) {
				if (connections[i]->getClientID() == client->getClientID()) {
					/* 다른 사용자와 게임 중이던 사람이 나간 경우 */
					if (connections[i]->getRoomID() != -1 &&
						clientCountInRoom(connections[i]->getRoomID()) == 2) {
						/* 남아있는 사람에게 메시지 전송 */
						exitClient(connections[i]->getRoomID());
					}
					connections.erase(connections.begin() + i);

					std::string conn = "[Users]"; //나갔을때의 User들을 불러옴(인원 재갱신)
					for (int i = 0; i < connections.size(); i++) {
						conn.append(connections[i]->getClientID());
						conn.append(",");
					}

					for (int i = 0; i < connections.size(); i++) {	// 클라이언트의 모든 사람들에게 Send를 보냄
						send(connections[i]->getClientSocket(), conn.c_str(), conn.length() - 1, 0);
					}
					break;
				}
			}
			mClient.unlock();
			delete client;
			break;
		}
	}
}

int main() {


	WSAStartup(MAKEWORD(2, 2), &wsaData); // MAKEWORD 0x0202가 반환됨, WSAStratup - 소켓함수의 시작.
	serverSocket = socket(AF_INET, SOCK_STREAM, NULL);

	serverAddress.sin_addr.s_addr = htonl(INADDR_ANY);
	serverAddress.sin_port = htons(9876);
	serverAddress.sin_family = AF_INET;

	std::cout << "[ C++ 오목 게임 서버 가동 ]" << std::endl;
	bind(serverSocket, (SOCKADDR*)&serverAddress, sizeof(serverAddress));
	listen(serverSocket, 32);

	int addressLength = sizeof(serverAddress);
	while (true) {
		SOCKET clientSocket = socket(AF_INET, SOCK_STREAM, NULL);
		if (clientSocket = accept(serverSocket, (SOCKADDR*)&serverAddress, &addressLength)) {
			Client* client = new Client(clientSocket);
			CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)ServerThread, (LPVOID)client, NULL, NULL);
		}
		Sleep(100);
	}
}