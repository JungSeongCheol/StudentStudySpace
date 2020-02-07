#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <Lm.h>
#include <VersionHelpers.h>

#pragma comment(lib, "netapi32.lib")
#define BUFFER 8192

int main(void)
{

    char value[255];
    DWORD BufferSize = BUFFER;

    RegGetValue(HKEY_LOCAL_MACHINE, "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "SystemRoot", RRF_RT_ANY, NULL, (PVOID)&value, &BufferSize);

    char buffer[MAX_COMPUTERNAME_LENGTH + 1];
    char buffer1[1000];
    DWORD size = 55;
    if (GetComputerName(buffer, &size))
    {
        printf("시스템 이름 : %s\n", buffer);
    }

    buffer[1000];

    if (GetUserName(buffer1, &size))
    {
        printf("사용자 이름 : %s\n", buffer1);
    }

    printf(" OS 이름 : ");
    VersionCheck();


}

int VersionCheck()
{
    if (IsWindowsXPOrGreater() == 0)
    {
        printf("Windows XP아래\n");
    }

    if (IsWindowsXPSP1OrGreater() == 0)
    {
        printf("XPSP1O보다 작다\n");
    }

    if (IsWindowsXPSP2OrGreater() == 0)
    {
        printf("XPSP2O 보다 작다\n");
    }

    if (IsWindowsXPSP3OrGreater() == 0)
    {
        printf("XPSP3O보다 작다\n");
    }

    if (IsWindowsVistaOrGreater() == 0)
    {
        printf("XPSP vista보다 작다\n");
    }

    if (IsWindowsVistaSP1OrGreater() == 0)
    {
        printf("Vista SP10 보다 작다\n");
    }

    if (IsWindowsVistaSP2OrGreater() == 0)
    {
        printf("Vista SP2O 보다 작다\n");
    }

    if (IsWindows7OrGreater() == 0)
    {
        printf("Windows7보다 작다.\n");
    }

    if (IsWindows7SP1OrGreater() == 0)
    {
        printf("Windows7 SP10보다 작다.\n");
    }

    if (IsWindows8OrGreater() == 0)
    {
        printf("Windows8보다 작다.\n");
    }

    if (IsWindows10OrGreater() == 0)
    {
        printf("Windows 10 Pro");
    }
}
//
////RegistryKey reg = Registry.LocalMachine;
////reg = reg.OpenSubKey("Software\\GeoService\\GeoService-Xr", true);
////
////if (reg != null)
////{
////    Object val = reg.GetValue("INSTALL_PATH");
////    if (null != val)
////    {
////        MessageBox.Show(Convert.ToString(val));
////    }
////}
//
//#define BUFFER 8192