*******************************************************************************
*******************************************************************************
**                                                                           **
**        (c) Copyright 2002 INTEGRA Consultants                             **
**                                                                           **
*******************************************************************************
*******************************************************************************
*******************************************************************************
** Pgm   : VIVA1                                                        &&T  **
** Desc. : Main program for VIVASoft project                            &&T  **
*******************************************************************************
** EC1  02/07/31 Original version                                            **
*******************************************************************************

CLEAR
CLEAR ALL
CLEAR WINDOWS
CLOSE ALL
CLOSE PROCEDURE
RELEASE ALL
APPLICATION.VISIBLE = .F.

PUBLIC no_version, m0frch, m0flat, m0xp, m0xpxcheme, m07to8, m0checkdb
STORE .t.     to m0checkdb
STORE 2002.00 TO no_version
STORE .T.     TO m0frch && Lui, il marche en FRAMCAiS
STORE .f.     TO m0flat && Lui, il marche en 3D
STORE .f.     TO m0xp
STORE .f.     TO m0xpscheme
STORE .T.     TO m07to8

*DO FORM VivaSplash
APPLICATION.VISIBLE = .T.

* Make sure that the project manager is closed.
DEACTIVATE WINDOW 'Project Manager'

DEACTIVATE WINDOW 'Properties'

* Set initial environment.
_SCREEN.Lockscreen = .T. && Don't show the changes now
_SCREEN.WindowState = 2
_SCREEN.Closable = .F.
_SCREEN.icon = "VivaSoft.ico"
PUSH MENU _MSYSMENU
CLEAR
* Display blank menu.
SET SYSMENU TO
*_SCREEN.Picture = "VIVAOK.jpg"
* Logo
	IF TYPE('_SCREEN.imgLogo') <> 'O'
   		_SCREEN.AddObject('imgLogo','image')
	ENDIF
	WITH _SCREEN.imgLogo
    	.Picture = "WSLogo.jpg"
    	.BackStyle = 0
    	* Center logo.
    	*.Top = (_SCREEN.Height-_SCREEN.imgLogo.Height)/2
    	.Top = _SCREEN.Height - _SCREEN.imgLogo.Height - 10
    	.Left = (_SCREEN.Width-_SCREEN.imgLogo.Width)/2
    	.Visible = .T.
    ENDWITH

_SCREEN.Lockscreen = .F.

** = NUMLOCK(.T.)                  && turn numlock on
** = CAPSLOCK(.T.)                 && turn capslock on
SET BELL       OFF
** SET CENTURY    OFF
SET CENTURY    ON
SET CLOCK      OFF
SET CONFIRM    OFF
SET CONSOLE    ON
*!*	SET DATE       DMY              
SET DEBUG      OFF
SET DECIMAL    TO 2
SET DELETED    ON
SET DOHISTORY  OFF
*SET ECHO       OFF
SET ESCAPE     OFF
SET EXACT      OFF
SET EXCLUSIVE  OFF
SET HELP       OFF
SET HOURS      TO 24
SET MULTILOCK  ON
SET NEAR       OFF 
SET REPROCESS  TO AUTOMATIC SYSTEM
SET SAFETY     OFF
SET SCOREBOARD OFF
SET STATUS     OFF
*SET STATUS BAR OFF
SET TALK       OFF
SET UDFPARMS   TO REFERENCE
SET LOCK       OFF
SET MULTILOCKS ON
*SET REFRESH    TO 0


*--------------------------------------*
SET FUNCTION F2  TO ";"
SET FUNCTION F3  TO ";"
SET FUNCTION F4  TO ";"
SET FUNCTION F5  TO ";"
SET FUNCTION F6  TO ";"
SET FUNCTION F7  TO ";"
SET FUNCTION F8  TO ";"
SET FUNCTION F9  TO ";"
SET FUNCTION F10 TO ";"
SET FUNCTION F11 TO ";"
SET FUNCTION F12 TO ";"

* TEMPORAIRE
*!*	IF DATE() > DATE(2002,03,15)
*!*		=MESSAGEBOX("ERROR LOADING WINFREIGHT",0+16,"FATAL ERROR")
*!*		QUIT
*!*	endif

**===========================================================**
**=== pour utilisateurs ===
ON KEY LABEL ALT-F2 SET CLOCK ON               && Afficher heure 
ON KEY LABEL ALT-F10 SUSPEND
ON KEY LABEL ALT-F1  DO XXALTF1      && Modif demo

SET PROCEDURE TO WSERROR ADDITIVE
SET PROCEDURE TO WSFUNCTION ADDITIVE && *
SET CLASSLIB TO VFPDATEPICKER ADDITIVE
SET CLASSLIB TO BZPRNLIB ADDITIVE
SET CLASSLIB TO WWIPSTUFF ADDITIVE
SET PROCEDURE TO wsutil ADDITIVE && *
SET PROCEDURE TO export ADDITIVE
SET PROCEDURE TO WWUTILS ADDITIVE  
SET PROCEDURE TO WWEVAL ADDITIVE
SET PROCEDURE TO WWHTTP ADDITIVE
SET PROCEDURE TO WSprintform ADDITIVE  && ***
** SET PROCEDURE TO MYSQL_SYNC_INC ADDITIVE
SET PROCEDURE TO MYSQL_2 ADDITIVE
SET PROCEDURE TO wsagentbatch ADDITIVE
SET PROCEDURE TO MD5 ADDITIVE
SET PROCEDURE TO wwDotNetBridge.prg ADDITIVE
SET PROCEDURE TO wwSMTP.prg ADDITIVE
SET PROCEDURE TO mysql_edi ADDITIVE			
*ON SHUTDOWN KEYBOARD '{CTRL+Y}'


**=========================================================================**

PUBLIC oSession, oReindexer, oVivaSoft, MySQL_lnHandle, gidclient, gmd5, TV, trfval, loc, IDPRODUIT
PUBLIC wMyLog, wMyErrorLog, MySQLError, MySQLExpectedCount, mySQLActualCount
PUBLIC wMyLog2, wMyErrorLog2, MySQLError2, MySQLExpectedCount2, mySQLActualCount2, MySQL_lnHandle2
PUBLIC MYSQL_LNHANDLE_IS_BOOL2
PUBLIC MySQL_show_progress AS Boolean
*PUBLIC DoMySQL 		
PUBLIC pArRep, pArLimited, lcDatabase, iswebemail, lcimp, blcouriel, vmaint	
STORE 0   TO pArRep      && For users that are rep, this is their rep id
STORE .F. TO pArLimited  && The user is limited to his own accounts
STORE .F. TO lset_menu
gMD5 = CREATEOBJECT("MD5")
 isPompoThere = .F.
* PUBLIC DoMySQL as Boolean

* Mysql
STORE 0 TO MySQL_lnHandle
wMyLog				= ""
wMyErrorLog			= ""
MySQLError 			= ""
MySQLExpectedCount 	= 0
MySQLActualCount   	= 0
iswebemail          = .F.
STORE 0 TO MySQL_lnHandle2	
wMyLog2				    = ""		
wMyErrorLog2			= ""		
MySQLError2 			= ""		
MySQLExpectedCount2 	= 0		
MySQLActualCount2   	= 0		
MYSQL_LNHANDLE_IS_BOOL2 = .F.	
TV = .F.
trfval=0
loc=""	
vmaint=""


SET CLASSLIB TO Reindexer ADDITIVE                && Objet pour build METADATA TABLE CONTENANT LES INDEXES DU SYSTÈME
oReindexer = CREATEOBJECT('indexer','WINSYS')        && Sert aussi pour le rebuild des indexes

***************************************************
****************************************************
SET CLASSLIB TO WsAppTest ADDITIVE
SET CLASSLIB TO WsAppBridge ADDITIVE
SET CLASSLIB TO loopbackeventhandler ADDITIVE
****************************************************
PUBLIC oSession, oSession2, xwssession, loLoopbackHandler, loLoopbackEventSubscription 

DO wwDotNetBridge && Load library wwDotNetBridge 

PUBLIC loBridge as wwDotNetBridge
loBridge = CreateObject("wwDotNetBridge","V4")
loBridge.EnableThrowOnError()

loBridge.LoadAssembly("C:\Users\Multi-Service\source\repos\CoquilleViva\CoquilleViva\bin\Debug\CoquilleViva.dll")

oSession2 = loBridge.CreateInstance("CoquilleViva.WsSession")
oSession2.Init()

loLoopbackHandler = CREATEOBJECT("LoopbackEventHandler")
loLoopbackEventSubscription = loBridge.SubscribeToEvents(oSession2, loLoopbackHandler)

xwssession = CREATEOBJECT('wssession')
oSession = CREATEOBJECT('wssession2')

*oSession.do_init()

SET STEP ON
DIMENSION xwssession.MOISTXT(12)
xwssession.MOISTXT[1] = "Janvier"
xwssession.MOISTXT[2] = "Février"
? xwssession.MOISTXT(1)
? xwssession.MOISTXT(2)

MESSAGEBOX(oSession2["test"])

*!*	 DIMENSION oSession.JOURTXT(7)
*!*	oSession.MOISTXT[1] = "Janvier"
*!*	oSession.JOURTXT[1] = "Dimanche"
*!*	? oSession.MOISTXT(1)
*!*	? oSession.JOURTXT(1)
*!*	*SET STEP ON
*!*	loArray = loBridge.InvokeMethod(oSession2,"getMoisTxt")

*!*	FOR i = 0 to loArray.Count -1
*!*	   loItem = loArray.Item(i)
*!*	   ? loItem 
*!*	ENDFOR

*!*	loArray.SetItem(0, "Janv")
*!*	loBridge.InvokeMethod(oSession2,"setmoistxt",loArray)

*!*	? loArray.Item(0)
*!*	loArray(1) = "Janvier"
*!*	loArray(2) = "Février"
*!*	loArray(3) = "Mars"
*!*	loArray(4) = "Avril"
*!* ? loArray.Item(0)
*!*	? loArray[1]
*!*	? loArray[2]
*!*	? loArray[3]
*!*	? loArray[4]


*? oSession.cDate(date(),.T.)
*LOCAL locSession

*locSession = "in coquillefoxpro.prg :" + CHR(13) + CHR(10);

***? STR(oSession.fBackColor) + CHR(13) + CHR(10)  
*!*	? STR(oSession.fForeColor) + CHR(13) + CHR(10)
*!*	? STR(oSession.fdisabledBackColor) + CHR(13) + CHR(10)  
*!*	? STR(oSession.fdisabledForeColor) +CHR(13) + CHR(10)   
*!*	? STR(oSession.LBackColor) + CHR(13) + CHR(10)   
*!*	? STR(oSession.LForeColor) +CHR(13) + CHR(10)    
*!*	? STR(oSession.LdisabledBackColor) + CHR(13) + CHR(10)   
*!*	? STR(oSession.LdisabledForeColor) + CHR(13) + CHR(10)   
*!*	? STR(oSession.WBackColor) + CHR(13) + CHR(10)   
*!*	? STR(oSession.WForeColor) +CHR(13) + CHR(10)             
*!*	? STR(oSession.BForeColor) +CHR(13) + CHR(10)   
*!*	? STR(oSession.BdisabledForeColor) +CHR(13) + CHR(10)     
*!*	? oSession.tmppath +CHR(13) + CHR(10)  
*!*	? oSession.NOBRACELET + CHR(13) + CHR(10)
*!*	? oSession.opened
*!*	? oSession.loginscreen
*!*	? oSession.cie_id
*STRTOFILE(locSession, "session.txt", 1)
RETURN

*#####################################################*
IF oSession.Opened = .T. 
	*DO FORM wsSplash
	oSession.Logon
	IF EMPTY(oSession.UserCode)
		oSession.Opened = .F.
	ENDIF
ENDIF

* oSession.wich_email="CDOSYS"

IF oSession.Opened = .T.
	oSession.curapplication = "VIVASoftXX"
	oSession.nocheckcredit = .F.
*!*		IF ALLTRIM(oSession.licence) = "0CC0XX0001" OR ALLTRIM(oSession.licence) = "8C00XX0002"
*!*			SET DATE       DMY              
*!*		ELSE
*!*			SET DATE       MDY              
*!*		ENDIF


	IF oSession.date_format = "DMY"
		SET DATE DMY
	ELSE
		SET DATE MDY
	ENDIF

	PUBLIC oPrintForm
	oPrintForm = CREATEOBJECT('WsPrintForm')

        
	* For client tracking update
    PUBLIC oTracking
    oTracking = CREATEOBJECT("wwIPStuff")
	oTracking.cHTTPProxyName = ""   && for ie7

	IF !EMPTY(oSession.proxyname)
*		oTracking.nHTTPConnectType = 3   && Manual Proxy Config
		oTracking.nHTTPConnectType = oSession.ProxyHTTPConnectType  
		oTracking.cHTTPProxyName = ALLTRIM(oSession.proxyname) && ex.:"192.9.200.249:3128"
		IF !EMPTY(oSession.proxyuser)
			oTracking.cHTTPProxyUserName = ALLTRIM(oSession.proxyuser)
		ENDIF
		IF !EMPTY(oSession.proxypass)
			oTracking.cHTTPProxyPassword = ALLTRIM(oSession.proxypass)
		ENDIF
	ENDIF
	*---------------------------------------------------------------
	* CHEZ MULTI-SERVICE ON A PAS CA DANS WSCIE - HARDCODED HERE
*!*		DO CASE
*!*			CASE THISFORM.wspageframe1.page4.scnProxyConnect.Value = 2
*!*				REPLACE wscie.ProxyHTTPConnectType WITH 1 && DIRECT
*!*			CASE THISFORM.wspageframe1.page4.scnProxyConnect.Value = 3
*!*				REPLACE wscie.ProxyHTTPConnectType WITH  0  && PRECONFIG
*!*			CASE THISFORM.wspageframe1.page4.scnProxyConnect.Value = 4
*!*				REPLACE wscie.ProxyHTTPConnectType WITH  3 && pROXY
*!*			CASE THISFORM.wspageframe1.page4.scnProxyConnect.Value = 5
*!*				REPLACE wscie.ProxyHTTPConnectType WITH  4 && PRECONFIG
*!*			OTHERWISE
*!*				REPLACE wscie.ProxyHTTPConnectType WITH  -1  && DEFAULT
*!*		ENDCASE	
	oSession.ProxyHTTPConnectType = 4
	
	set classlib to pdialog additive
    oprn=createobject("pdialog.pdialog")
	
	
	SET CLASSLIB TO WsVivaSoft ADDITIVE    
	oVivaSoft = CREATEOBJECT('WsVivaSoft')
    
	* Vérifie s'il y a des nouveaux messages interne
    oSession.check_mesg("SHOW")



 SET CLASSLIB TO rawprint ADDITIVE  
    PUBLIC oPrndev
    oPrndev = CREATEOBJECT('printdev')
    oPrndev.cdocname = "Document from files"
    oPrndev.cprintername = SET('printer',3)


	ON ERROR DO traperror WITH PROGRAM(), LINENO()
	*ON KEY LABEL F1 ;
	*		DO globalpad WITH _SCREEN.ActiveForm, ;
	*						  _SCREEN.ActiveForm.CurrentControl
*!*								  UPPER(PROGRAM()), UPPER(POPUP()), ;
*!*	                              UPPER(PROMPT()), UPPER(VARREAD()),;
*!*	                              SUBSTR(UPPER(SYS(16)), RAT("\", SYS(16)) + 1)

	**** menu
	DO VIVASoft.mpr



	*****
	***** Add web page
*	_SCREEN.AddObject('News1', 'WsNews')
*	_SCREEN.News1.navigate("C:/WinSys/Help/Winsys.htm")

	_SCREEN.imgLogo.Visible = .F. && Take out this logo

	* Main system bar
	SET CLASSLIB TO VivaBars ADDITIVE
	oWsBar = CREATEOBJECT('WsMainBar')
*!*		oWsBar.show
*!*		oWsBar.dock(0)
	oSession.Launch_bar(oWsBar)

	* Current working period bar
	IF ALLTRIM(oSession.UserType) == "Accounting"
		oWsWorkPer = CREATEOBJECT('WsWorkPer')
*!*		*!*		oWsBar.show
*!*		*!*		oWsBar.dock(0)
		oSession.Launch_bar(oWsWorkPer)
	ENDIF
	
***	oWsBanner = CREATEOBJECT('WsBanner')
*!*		oWsBanner.dock(0)
*!*		oWsBanner.show
***	oSession.Launch_bar(oWsBanner)
     
		
	*PowerBar (variable by user)
*!*		oWsPowerBar = CREATEOBJECT('WsPowerBar')
*!*		oSession.Launch_bar(oWsPowerBar)
*!*	oWsPowerBar.show
 
	USE wsuser
	SET ORDER TO code
	SEEK ALLTRIM(oSession.UserCode)
	IF FOUND()
		IF !EMPTY(wsuser.ubar1) OR !EMPTY(wsuser.ubar2) AND;
	   	   !EMPTY(wsuser.ubar3) OR !EMPTY(wsuser.ubar4) AND;
	       !EMPTY(wsuser.ubar5) OR !EMPTY(wsuser.ubar6) AND;
	       !EMPTY(wsuser.ubar7) OR !EMPTY(wsuser.ubar8) AND;
	       !EMPTY(wsuser.ubar9) OR !EMPTY(wsuser.ubar10)
			oWsPowerBar = CREATEOBJECT('WsPowerBar')
			oSession.Launch_bar(oWsPowerBar)
		ENDIF
		IF TYPE("wsuser.set_menu") = "L"
			STORE wsuser.set_menu     TO lset_menu
		ENDIF
		STORE wsuser.ArRep      TO pArRep
		STORE wsuser.Limited    TO pArLimited
	ENDIF
	USE

	*---- Main screen preparation ------------*
	
	_SCREEN.Lockscreen = .T. && Don't show the next changes immediately

	*_SCREEN.Picture = "WSBack.jpg" && Put background
	IF FILE(ALLTRIM(oSession.sPicture))
		_SCREEN.Picture = oSession.sPicture
	ELSE
		_SCREEN.Picture = "WSBACK.JPG"
	ENDIF
	SET CLASSLIB TO 'Wsctrl.vcx' ADDITIVE
	
    *---------------------------------------------------------------*
    *  Screen banner image                                       *
    *---------------------------------------------------------------*
	IF TYPE('_SCREEN.imgBanner') <> 'O'
   		_SCREEN.AddObject('imgBanner','image')
	ENDIF
	*WITH _SCREEN.imgBanner
    	* .Picture = "WSBanner.jpg"
    *	 .BackStyle = 1
    	* .Top  = 250
    	* .Left = 375
    	* .Visible = .T.
   * ENDWITH
    *---------------------------------------------------------------*
    _SCREEN.Lockscreen = .F.
 
   *  oSession.fourn_valide
	DO FORM wsrecherche
	DO FORM FORM_COBIL

	*****
	***** Add backscreen element 1 : link vivasoft
	*****
	SET CLASSLIB TO 'Wsemail.vcx' ADDITIVE
	_SCREEN.AddObject('LinkWWWviva','wswwwviva')
	WITH _SCREEN.LinkWWWviva
    	.ForeColor = RGB(255,0,0) && Red
    	* Center logo.
    	*.Top = (_SCREEN.Height-_SCREEN.imgLogo.Height)/2
    	.Top = _SCREEN.Height - 15
    	*.Left = _SCREEN.Width - 10
    	*.Top = 110
    	.Left = 10
    	.Visible = .T.
    ENDWITH

	_SCREEN.AddObject('MyTimer','wstimer')
	WITH _SCREEN.MyTimer
	   	.interval= oSession.usertimer * 60000
	ENDWITH

    

*!*		*****
*!*		***** Add backscreen element 1 : send all mail icon
*!*		*****
*!*		SET CLASSLIB TO '\WinSys\Lib\Wsemail.vcx' ADDITIVE
*!*		_SCREEN.AddObject('LinkSendAll','wsemail_send_all')
*!*		WITH _SCREEN.LinkSendAll
*!*	    	.Top = _SCREEN.Height - 40
*!*	    	.Left = 10
*!*	    	.Visible = .T.
*!*	    ENDWITH
*!*		*****
*!*		***** Add backscreen element 1 : SHORTCUT 1...
*!*		*****
*!*		_SCREEN.AddObject('LinkShortCut1','ws_shortcut1')
*!*		WITH _SCREEN.LinkShortCut1
*!*	    	.Top = _SCREEN.Height - 40
*!*	    	.Left = 80
*!*	    	.Visible = .T.
*!*	    ENDWITH
*!*		_SCREEN.AddObject('LinkShortCut2','ws_shortcut2')
*!*		WITH _SCREEN.LinkShortCut2
*!*	    	.Top = _SCREEN.Height - 40
*!*	    	.Left = 120
*!*	    	.Visible = .T.
*!*	    ENDWITH
    
	_SCREEN.Lockscreen = .F.
	*---- END Main screen preparation --------*

  
	* SESSION STARTS HERE
*    DO FORM wsNews.scx 
	*DO FORM wsStartup.scx
	
	IF oSession.development = .t.
		WAIT "WORKING IN DEVELOPMENT MODE" WINDOW NOWAIT
	ENDIF
	IF lset_menu
		DO FORM menuacct
	ENDIF
	
	READ EVENT
	
ENDIF
POP MENU _MSYSMENU
SET SYSMENU TO DEFAULT 
CLEAR
IF oSession.development = .t.
	SET CLASSLIB TO
	CLEAR MENUS
	CLEAR POPUPS
	CLEAR PROMPT
	CLEAR TYPEAHEAD
	CLEAR WINDOWS
	CLOSE ALL

	ON SHUTDOWN

	WAIT WINDOW "Returning to fox" NOWAIT
	RELEASE ALL

	RETURN
endif	
*SET CLASSLIB TO
*CLEAR MENUS
*CLEAR POPUPS
*CLEAR PROMPT
*CLEAR TYPEAHEAD
*CLEAR WINDOWS
*CLOSE ALL

* ON SHUTDOWN

QUIT
*WAIT WINDOW "Returning to fox" NOWAIT
* RELEASE ALL

RETURN



**===========================================================================**
** Called by ALT-F1 everywhere                                               **
**===========================================================================**
PROCEDURE XXALTF1

	WAIT "You pressed ALT-F1" WINDOW NOWAIT

RETURN

**===========================================================================**
** Function pad that is called everywhere with RIGHTCLICK                    **
**===========================================================================**
PROCEDURE globalpad
PARAMETER pcurform, pcurcontrol
PRIVATE pcurform, pcurcontrol
WAIT "pcurform:" + pcurform + " pcurcontrol:" + pcurcontrol WINDOW

RETURN

**===========================================================================**
** Standard function to use instead of messagebox for simple message         **
** Parameters : Message to display,                                          **
**              Title to display,                                            **
**===========================================================================**
FUNCTION xMessage
PARAMETER pmessage, ptitle

=MESSAGEBOX(pmessage, 0+64, ptitle)

RETURN
ENDFUNC
**===========================================================================**
** Standard function to use instead of messagebox for simple error message   **
** Parameters : Message to display,                                          **
**              Title to display,                                            **
**===========================================================================**
FUNCTION xError
PARAMETER pmessage, ptitle

=MESSAGEBOX(pmessage, 0+16, ptitle)

RETURN
ENDFUNC
**===========================================================================**
** Standard function to use instead of messagebox for simple message         **
** Parameters : Message to display,                                          **
**              Title to display,                                            **
**              Returns .T. = Yes                                            **
**===========================================================================**
FUNCTION xYesNo
PARAMETER pmessage, ptitle
LOCAL theanswer

theanswer=MESSAGEBOX(pmessage, 4+32+256, ptitle)
IF theanswer = 6
	RETURN .T. && Yes
ELSE
	RETURN .F. && No
ENDIF
ENDFUNC

*********
** eof **
*********

******************************************************
loLoopbackEventSubscription.unsubscribe()
