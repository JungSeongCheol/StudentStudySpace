#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include <io.h>
#include <conio.h>

typedef struct _finddata_t FILE_SEARCH;

// 메인함수
int main(void)
{
    FILE* fp;
    FILE* list;
    FILE_SEARCH t_file;
    intptr_t hFile;
    char dir[100] = "d:\\document\\";
    char buf[100];
    int i = 0;
    int fileList;
    int check = 1;
    int ch;
    int key;
    char temp[100];

    while (1) {
        if (kbhit()) {
            key = getch();
            if (key == 'x') break;
        }

        if ((hFile = _findfirst("d:\\document\\*.txt", &t_file)) == -1L) {}
        else {
            do {
                check = 1;
                list = fopen("d:\\document\\list", "r+");

                while (1) {

                    if (fgets(buf, sizeof(buf), list) == NULL) break;
                    buf[strlen(buf) - 1] = '\0';
                    if (strcmp(buf, t_file.name) == 0) {
                        check = 0;
                    }
                }

                if (check == 0) continue;

                strcpy(temp, t_file.name);

                fputs(t_file.name, list);
                fputc('\n', list);

                strcpy(dir, "d:\\document\\");
                strcat(dir, t_file.name);

                fp = fopen(dir, "r");

                while (1) {
                    if (fgets(buf, sizeof(buf), fp) == NULL) break;
                    printf("%s", buf);
                }
                putchar('\n');

                fclose(fp);
                fclose(list);
            } while (_findnext(hFile, &t_file) == 0);
            _findclose(hFile);
        }
        _sleep(1000);
    }
    return EXIT_SUCCESS;
}