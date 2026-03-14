!include "MUI2.nsh"

Name "Certificate Manager"
OutFile "CertificateManager-Setup.exe"
InstallDir "$LOCALAPPDATA\Certificate Manager"  ; Папка пользователя, без защиты
RequestExecutionLevel user  ; Не требует прав администратора

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_DIRECTORY  
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

!insertmacro MUI_UNPAGE_WELCOME
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH

!insertmacro MUI_LANGUAGE "Russian"
!insertmacro MUI_LANGUAGE "English"

Section "MainSection" SEC01
    SetOutPath "$INSTDIR"
    File /r "bin\Debug\*"  ; Берет все из папки Debug (включая Excel файлы)
    
    CreateShortCut "$DESKTOP\Certificate Manager.lnk" "$INSTDIR\Certificate.exe"
    CreateShortCut "$SMPROGRAMS\Certificate Manager.lnk" "$INSTDIR\Certificate.exe"
    
    WriteUninstaller "$INSTDIR\uninstall.exe"
SectionEnd

Section "Uninstall"
    Delete "$DESKTOP\Certificate Manager.lnk"
    Delete "$SMPROGRAMS\Certificate Manager.lnk"
    RMDir /r "$INSTDIR"
SectionEnd