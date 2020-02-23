#include <stdio.h>
#include <stdlib.h>

#define true 1
#define false 0

typedef int bool;

typedef struct _card {
	char name[30];
	char com[30];
	char Pnum[20];
	struct _card* next;
} card;

card* head;
card* for_delete;
bool load_flag = false;
/* load()�� �����ߴٸ� save()�� �������� ���
 �� ���� ���� ����� ���� ����.
 If Program runs load(), Paste the save data
 in case User already chose save().
*/

void Input(card* c1);
void Delete(card* c);
bool Search(card* c);
void Load(card* c);
void Save(card* c);
void List(card* c);
void all_delete(card* c);

int main() {
	int sel;
	//flag�� ���� ���� ���� �ʴ�.
	//Many of flag isn't good.
	bool flag = false; // ���Ḧ ���� �÷���	
			   // flag for exit
	bool don_meaning;  // bool search�� ����ϱ� ���� �÷���
			   // flag for search()(search()'s return type
			   // is bool.
	card* c;
	card* tmp;

	c = (card*)malloc(sizeof(card));
	c->next = NULL;
	// next���� ������� ���� ���� NULL�� �� �־�����.
	// I inputted NULL to last node's next.

	head = c;
	/*
	�޸� ������ ����
	ù��° ������ ���� ���ܵӴϴ�.
	First Pointer value left for free memory.
	*/

	while (1) {

		printf("Card Management Program\n\n");
		printf("#1. Input Namecard#\n");
		// ������ �Է� �޴´�.
		// input namecard
		printf("#2. Delete Namecard#\n");
		// ������ �����Ѵ�. : �̸����� ã��
		// delete namecard. : search as name
		printf("#3. Search Namecard#\n");
		// ������ �˻��Ѵ�. : �̸����� ã��
		// search namecard. : search as name.
		printf("#4. Load Namecard#\n");
		// ��ũ���� ���Ե��� �д´�.
		// load namecard from disk
		printf("#5. Save Namecard#\n");
		// ��ũ�� ������ �����Ѵ�.
		// save namecard.
		printf("#6. List Namecard#\n");
		// ���Ե��� ����Ʈ�� ȭ�鿡 �����ش�.
		// list namecard to screen(console).
		printf("#7. Print Namecard#\n");
		// ���Ե��� ����Ʈ�� �����ͷ� ����Ѵ�(�̰Ŵ� �Ұ���).
		// Print namecard to Printer(this is impossible.)
		printf("#8. End Program#\n");
		printf("-> ");
		scanf("%d", &sel);

		c = head;

		/*
		 * switch���� ���� �� ���� �Ʒ��� �ڵ带 �̿���
		 * ���� ��尡 �ǳ����� �̵��ϰ� �˴ϴ�.
		 *
		 * Every switch() is over, node moves to last node(for switch())
		 * as following code.
		 */
		while (c->next != NULL) {
			c = c->next;
		}

		switch (sel) {

		case 1:
			Input(c);
			break;
		case 2:
			Delete(head);
			break;
		case 3:
			don_meaning = Search(head);
			break;
		case 4:
			Load(c);
			break;
		case 5:
			Save(head);
			break;
		case 6:
			List(head);
			break;
		case 7:
			//Print();
			break;
		default:
			head->next = NULL; /*
						  ���α׷� �������ڸ��� ���α׷� ����� �ʿ��� �ڵ��Դϴ�.
						  As soon as program starts, program needs this code thanks because program is exited.
						*/
			all_delete(head);

			printf("\nProgram is Exited!\n");
			getch();

			return 0;
		}
		printf("Press any key..");
		getch();
		system("cls");
	}
}

void Input(card* c1) {

	c1->next = (card*)malloc(sizeof(card));
	c1 = c1->next;

	printf("Input the Name : ");
	scanf("%s", c1->name);
	fflush(stdin);
	printf("Input the Company : ");
	scanf("%s", c1->com);
	fflush(stdin);
	printf("Input the Phone-Number : ");
	scanf("%s", c1->Pnum);
	fflush(stdin);

	c1->next = NULL;
}
void Delete(card* c) {
	char name[30];
	char sel;
	bool flag = false;
	card* t;

	printf("========Delete========\n\n");

	while (1) {
		fflush(stdin);
		printf("If you want to exit, press (N/n) key.\n");
		printf("For progress.. Press key -> ");
		scanf("%c", &sel);
		fflush(stdin);

		if (sel == 'N' || sel == 'n') {
			break;
		}

		flag = Search(head);
		c = for_delete;
		c = c->next;


		if (flag == true) {

			printf("Do you want to remove?(y/n) : ");
			scanf("%c", &sel);
			fflush(stdin);

			if (sel == 'N' || sel == 'n') {
				break;
			}

			t = c;
			c = for_delete;
			c->next = c->next->next;
			free(t);
			printf("...Deleting OK!!\n");
		}
		if (head->next == NULL) {
			c = (card*)malloc(sizeof(card));
			c->next = NULL;
		}

	}
}

bool Search(card* c) {
	char name[30];
	bool flag = false; /*
				  ã�⿡ �����ߴ°��� ���ϴ�.
				  true == success, false == fail.
				  examine that search is success.
				*/



	if (head->next == NULL) {
		printf("Um.. Not data..\n");
	}
	else {

		printf("Search for the Name: ");
		scanf("%s", name);
		fflush(stdin);

		while (c->next != NULL) {
			for_delete = c; // �ش� �� ���� ��带 ����Ŵ.
					// indicate previous node.
			c = c->next;
			//�� c->name==name�� �����ϴ��� �˼��� ����,��;;;
			//I don't know why c->name==name is error.
			if (strcmp(c->name, name) == 0) {
				flag = true; // ã�⿡ �����߽��ϴ�.	
						 // Search is success.
				break;
			}
		}
	}

	// �������� ȿ���� ���� �÷��׸� �̿��Ͽ� �ڵ带 �̵��߽��ϴ�.
	// I move code by using flag. this work is for readability.
	if (flag == true) {
		printf("Name : %10s Company : %10s PhoneNumber : %10s\n", c->name, c->com, c->Pnum);
	}
	else {
		printf("..Searching Failed.\n");
	}

	return flag;
}

void Load(card* c) {
	FILE* f;
	char* ch = NULL;

	card* t = (card*)malloc(sizeof(card));


	if ((f = fopen("c:\\c\\data.txt", "r+t")) == NULL) {
		puts("error");
		exit(0);
	}

	while (!feof(f)) {
		c->next = (card*)malloc(sizeof(card));
		c = c->next;
		fscanf(f, "%s ", c->name);
		fscanf(f, "%s ", c->com);
		fscanf(f, "%s ", c->Pnum);
		c->next = NULL;

		if (strcmp(c->name, t->name) == 0) {
			free(c);
			free(t);
			head->next = NULL;
		}
	}
	load_flag = true;
	fclose(f);
}

void Save(card* c) {
	FILE* f;

	if (load_flag = true) {
		if ((f = fopen("c:\\c\\data.txt", "w+t")) == NULL) {
			puts("error");
			exit(0);
		}
		load_flag = false;
	}
	else if (load_flag = false) {
		if ((f = fopen("c:\\c\\data.txt", "a+t")) == NULL) {
			puts("error");
			exit(0);
		}
	}

	while (c->next != NULL) {
		c = c->next;
		if (f != NULL)
			fprintf(f, "%s %s %s\n", c->name, c->com, c->Pnum);
	}
	all_delete(head);

	c = (card*)malloc(sizeof(card));
	c->next = NULL; // next���� ������� ���� ���� NULL�� �� �־�����.
			// If node->next value is empty, input the NULL.
	head = c;

	fclose(f);
}

void List(card* c) {
	int i = 1;

	if (head->next == NULL) {
		printf("Um.. Not data..\n");
	}
	else {
		while (c->next != NULL) {
			c = c->next;
			printf("%d. Name : %10s Company : %10s PhoneNumber : %10s\n", i, c->name, c->com, c->Pnum);
			i++;
		}
	}
}

void all_delete(card* c) {
	card* t; // �޸� ������ ����.
		 // for memory free.

	while (c->next != NULL) {
		t = c;
		c = c->next;
		free(t);
	}

	free(c);
	head->next = NULL;
}

//#include <stdio.h>
//#include <stdlib.h>
//
//#define NAME_SIZE 21
//#define CORP_SIZE 31
//#define TEL_SIZE 16
//#define REC_SIZE (NAME_SIZE + CORP_SIZE + TEL_SIZE)
//
//typedef struct _card {
//	char name[NAME_SIZE];
//	char corp[CORP_SIZE];
//	char tel[TEL_SIZE];
//	struct _card* next;
//} card;
//
//card* head, * tail;
//
//void init_card(void) {
//	head = (card*)malloc(sizeof(card));
//	tail = (card*)malloc(sizeof(card));
//	head->next = tail;
//	tail->next = tail;
//}
//
//void input_card(void) {
//	card* t;
//	t = (card*)malloc(sizeof(card));
//
//	printf("\nInput namecard menu : ");
//	printf("\n Input name -> ");
//	gets(t->name);
//	printf("\n Input corporation -> ");
//	gets(t->corp);
//	printf("\n Input telephone number -> ");
//	gets(t->tel);
//
//	t->next = head->next;
//	head->next = t;
//}
//
//void print_card(card* t, FILE* f) {
//	fprintf(f, "\n%-20s %-30s %-15s", t->name, t->corp, t->tel);
//}
//
//void print_header(FILE* f) {
//	fprintf(f, "\nName\t\t"
//		"Corporation\t\t"
//		"Telephone number");
//	fprintf(f, "\n-------------------   "
//		"---------------------------   "
//		"-------------------");
//}
//
//void load_cards(char* s) {
//	FILE* fp;
//	card* t;
//	card* u;
//
//	if ((fp = fopen(s, "rb")) == NULL) {
//		printf("\n  Error : %s is not exist.", s);
//		return;
//	}
//	t = head->next;
//	while (t != tail) {
//		u = t;
//		t = t->next;
//		free(u);
//	}
//	head->next = tail;
//	while (1) {
//		t = (card*)malloc(sizeof(card));
//		if (!fread(t, REC_SIZE, 1, fp)) {
//			free(t);
//			break;
//		}
//		t->next = head->next;
//		head->next = t;
//	}
//	fclose(fp);
//}
//
//void save_cards(char* s) {
//	FILE* fp;
//	card* t;
//
//	if ((fp = fopen(s, "wb")) == NULL) {
//		printf("\n   Error : Disk write failure.");
//		return;
//	}
//	t = head->next;
//	while (t != tail) {
//		fwrite(t, REC_SIZE, 1, fp);
//		t = t->next;
//	}
//	fclose(fp);
//}
//
//int delete_card(char* s) {
//	card* t;
//	card* p;
//
//	p = head;
//	t = p->next;
//	while (strcmp(s, t->name) != 0 && t != tail) {
//		p = p->next;
//		t = p->next;
//	}
//	if (t == tail)
//		return 0;
//	p->next = t->next;
//	free(t);
//	return 1;
//}
//
//card* search_card(char* s) {
//	card* t;
//
//	t = head->next;
//	while (strcmp(s, t->name) != 0 && t != tail)
//		t = t->next;
//	if (t == tail)
//		return NULL;
//	else
//		return t;
//}
//
//int select_menu(void) {
//	int i;
//	char s[10];
//
//	printf("\n\nNAMECARD Manager");
//	printf("\n----------------------------");
//	printf("\n1. Input  Namecard");
//	printf("\n2. Delete Namecard");
//	printf("\n3. Search Namecard");
//	printf("\n4. Load   Namecard");
//	printf("\n5. Save   Namecard");
//	printf("\n6. List   Namecard");
//	printf("\n7. Print  Namecard");
//	printf("\n8. End    Program");
//
//	do {
//		printf("\n\n   : select operation -> ");
//		i = atoi(gets(s));
//	} while (i < 0 || i>8);
//
//	return i;
//}
//
//int main(void) {
//	char* fname = "NAMECARD.DAT";
//	char name[NAME_SIZE];
//	int i;
//	card* t;
//	FILE* stdprn = fopen("LPT1", "wt");
//
//
//	init_card();
//	while ((i = select_menu()) != 8) {
//		switch (i) {
//		case 1:
//			input_card();
//			break;
//		case 2:
//			printf("\n\tInput name to delete -> ");
//			gets(name);
//			if (!delete_card(name)) /* �̸��� ã�� ���� ��� */
//							   /* When program doesn't find Name */
//				printf("\n\tCan't find that name.");
//			break;
//		case 3:
//			printf("\n\tInput name to search -> ");
//			gets(name);
//			t = search_card(name);
//			if (t == NULL) {
//				printf("\n\tCan't find that name.");
//				break;
//			}
//			print_header(stdout);
//			print_card(t, stdout);
//			break;
//		case 4:
//			load_cards(fname);
//			break;
//		case 5:
//			save_cards(fname);
//			break;
//		case 6:
//			t = head->next;
//			print_header(stdout);
//			while (t != tail) {
//				print_card(t, stdout);
//				t = t->next;
//			}
//			break;
//		case 7:
//			t = head->next;
//			print_header(stdprn);
//			while (t != tail) {
//				print_card(t, stdprn);
//				t = t->next;
//			}
//			break;
//		}
//	}
//	printf("\n\nProgram ends...");
//	return 0;
//}