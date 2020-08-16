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
class Client {
private:
	std::string clientID;
	int roomID;
	SOCKET clientSocket;
	std::string where;
public:
	Client(SOCKET clientSocket) {
		this->roomID = -1;
		this->clientSocket = clientSocket;
		where = "WaitingRoom";
	}
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

	void setWhere(std::string where) {
		this->where = where;	//현재 위치를 반환하기위한것인지(대기실인지, 아니면 게임방인지)
	}
};

class Room {
private:
	std::string r_roomName;
	int r_roomIdx;
public:
	Room(int roomIdx, std::string roomName) {
		r_roomName = roomName;
		r_roomIdx = roomIdx;
	}
	std::string getRoomName() {
		return r_roomName;
	}

	int getRoomIdx() {
		return r_roomIdx;
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

void putClient(int roomID, int x, int y) {
	char* sent = new char[256];
	for (int i = 0; i < connections.size(); i++) {
		if (connections[i]->getRoomID() == roomID) {
			ZeroMemory(sent, 256);
			std::string data = "[Put]" + std::to_string(x) + "," + std::to_string(y);
			sprintf(sent, "%s", data.c_str());
			send(connections[i]->getClientSocket(), sent, 256, 0);
		}
	}
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

	std::cout << "[ 새로운 사용자 [" << client->getClientID() << "] 접속 ]" << std::endl;

	while (true) {
		ZeroMemory(received, 256);
		if ((size = recv(client->getClientSocket(), received, 256, NULL)) > 0) {
			std::string receivedString = std::string(received);
			std::vector<std::string> tokens = getTokens(receivedString, ']');

			if (receivedString.find("[WaitingRoom]") != -1) {
				std::vector<std::string> WaitingRoomTokens = getTokens(tokens[1], 0x01);
				if (WaitingRoomTokens[0] == "Users") {
					std::string conn = "[Users]";
					mClient.lock();
					for (int i = 0; i < connections.size(); i++) {
						conn.append(connections[i]->getClientID());
						conn.append(",");
					}
					conn.erase(conn.end());

					for (int i = 0; i < connections.size(); i++) {
						send(connections[i]->getClientSocket(), conn.c_str(), conn.length(), 0);
					}
					mClient.unlock();
				}

				else if (WaitingRoomTokens[0] == "Chats") {
					std::string conn = "[Chat]" + client->getClientID() + ": " + WaitingRoomTokens[1];
					mClient.lock();
					for (int i = 0; i < connections.size(); i++) {
						send(connections[i]->getClientSocket(), conn.c_str(), conn.length(), 0);
					}
					mClient.unlock();
				}

				else if (WaitingRoomTokens[0] == "Exit") {
					std::string conn = "[Users]";
					mClient.lock();
					for (int i = 0; i < connections.size(); i++) {
						if (connections[i]->getClientID() == client->getClientID()) {
							continue;
						}
						conn.append(connections[i]->getClientID());
						conn.append(",");
					}
					conn.erase(conn.end());

					for (int i = 0; i < connections.size()-1; i++) {
						send(connections[i]->getClientSocket(), conn.c_str(), conn.length(), 0);
					}
					mClient.unlock();
				}
			}

			else if (receivedString.find("[PlayingRoom]") != -1) {
				std::vector<std::string> roomTokens = getTokens(tokens[1], 0x01);

				if (roomTokens[0] == "Create") {
					std::string conn = "[Create]" + roomTokens[1];
					mClient.lock();
					Room* room = new Room(++roomnumber, roomTokens[1]);
					rooms.push_back(room);
					send(client->getClientSocket(), conn.c_str(), conn.length(), 0);
					mClient.unlock();
				}

				else if (roomTokens[0] == "Refresh") {
					mRoom.lock();
					std::string conn = "[Refresh]";
					for (int i = 0; i < rooms.size(); i++) {
						conn.append(std::to_string(rooms[i]->getRoomIdx()));
						conn.append(",");
						conn.append(rooms[i]->getRoomName());
						conn.append(",");
					}
					mRoom.unlock();
					Sleep(10);
					mClient.lock();
					for (int i = 0; i < connections.size(); i++) {
						send(connections[i]->getClientSocket(), conn.c_str(), conn.length(), 0);
					}
					mClient.unlock();

				}
			}

			if (receivedString.find("[Enter]") != -1) {
				/* 메시지를 보낸 클라이언트를 찾기 */
				for (int i = 0; i < connections.size(); i++) {
					std::string roomID = tokens[1];
					int roomInt = atoi(roomID.c_str());
					if (connections[i]->getClientSocket() == client->getClientSocket()) {
						int clientCount = clientCountInRoom(roomInt);
						/* 2명 이상이 동일한 방에 들어가 있는 경우 가득 찼다고 전송 */
						if (clientCount >= 2) {
							ZeroMemory(sent, 256);
							sprintf(sent, "%s", "[Full]");
							send(connections[i]->getClientSocket(), sent, 256, 0);
							break;
						}
						std::cout << "클라이언트 [" << client->getClientID() << "]: " << roomID << "번 방으로 접속" << std::endl;
						/* 해당 사용자의 방 접속 정보 갱신 */
						Client* newClient = new Client(*client);
						newClient->setRoomID(roomInt);
						connections[i] = newClient;
						/* 방에 성공적으로 접속했다고 메시지 전송 */
						ZeroMemory(sent, 256);
						sprintf(sent, "%s", "[Enter]");
						send(connections[i]->getClientSocket(), sent, 256, 0);
						/* 상대방이 이미 방에 들어가 있는 경우 게임 시작 */
						if (clientCount == 1) {
							playClient(roomInt);
						}
					}
				}
			}

			//else if (receivedString.find("[Put]") != -1) {
			//	/* 메시지를 보낸 클라이언트 정보 받기 */
			//	std::string data = tokens[1];
			//	std::vector<std::string> dataTokens = getTokens(data, ',');
			//	int roomID = atoi(dataTokens[0].c_str());
			//	int x = atoi(dataTokens[1].c_str());
			//	int y = atoi(dataTokens[2].c_str());
			//	/* 사용자가 놓은 돌의 위치를 전송 */
			//	putClient(roomID, x, y);
			//}
			//else if (receivedString.find("[Play]") != -1) {
			//	/* 메시지를 보낸 클라이언트를 찾기 */
			//	std::string roomID = tokens[1];
			//	int roomInt = atoi(roomID.c_str());
			//	/* 사용자가 놓은 돌의 위치를 전송 */
			//	playClient(roomInt);
			//}
		}

		else {
			ZeroMemory(sent, 256);
			sprintf(sent, "클라이언트 [%s]의 연결이 끊어졌습니다.", client->getClientID().c_str());
			std::cout << sent << std::endl;
			/* 게임에서 나간 플레이어를 찾기 */
			for (int i = 0; i < connections.size(); i++) {
				if (connections[i]->getClientID() == client->getClientID()) {
					/* 다른 사용자와 게임 중이던 사람이 나간 경우 */
					if (connections[i]->getRoomID() != -1 &&
						clientCountInRoom(connections[i]->getRoomID()) == 2) {
						/* 남아있는 사람에게 메시지 전송 */
						exitClient(connections[i]->getRoomID());
					}
					connections.erase(connections.begin() + i);
					break;
				}
			}
			delete client;
			break;
		}
	}
}

int main() {


	WSAStartup(MAKEWORD(2, 2), &wsaData);
	serverSocket = socket(AF_INET, SOCK_STREAM, NULL);

	serverAddress.sin_addr.s_addr = inet_addr("127.0.0.1");
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
			//connections.push_back(*client);
			//nextID++;
		}
		Sleep(100);
	}
}