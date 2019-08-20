* Table creation - WINSYS - GENERAL
*
PROCEDURE wsinit
LPARAMETERS ptable

SET TALK OFF

SET CLASSLIB TO 'Wsctrl.vcx' ADDITIVE
LOCAL lc_path, lc_dbname
lc_dbname = "Winsys"

CLOSE DATABASES
OPEN DATABASE (lc_dbname)

STORE UPPER(ptable) TO ptable

IF ptable = "ALL" OR ptable = "WSCIE"
	DO cr_wscie
ENDIF
IF ptable = "ALL" OR ptable = "WSUSER"
	DO cr_wsuser
ENDIF
IF ptable = "ALL" OR ptable = "WSGROUP"
	DO cr_wsgroup
ENDIF
IF ptable = "ALL" OR ptable = "WSSEQ"
	DO cr_wsseq
ENDIF
IF ptable = "ALL" OR ptable = "WSLOG"
	DO cr_wslog
ENDIF
IF ptable = "ALL" OR ptable = "WSPERMIS"
	DO cr_wspermis
ENDIF
IF ptable = "ALL" OR ptable = "WSFUNCTION"
	DO cr_wsfunction
ENDIF
IF ptable = "ALL" OR ptable = "WSLANG"
	DO cr_wslang
ENDIF
IF ptable = "ALL" OR ptable = "WSTRANSL"
	DO cr_wstransl
ENDIF
IF ptable = "ALL" OR ptable = "VIEW" OR ptable = "V1WSPERMIS"
	DO cr_v1wspermis
ENDIF

CLOSE DATABASES
RETURN

*-----------------------------------------------------------------------*
* WSPERMIS - SYSTEM PERMISSIONS
*-----------------------------------------------------------------------*
PROCEDURE cr_wspermis

REMOVE TABLE WsPermis DELETE
CREATE TABLE WsPermis ;
      (Group    c(10), ;
       Function c(15),;
       Ajout    l,;
       Modif    l,;
       Supp     l,;
       Imp      l)
       
INDEX ON Group+ALLTRIM(Function) TAG Ident
       
RETURN
*-----------------------------------------------------------------------*
* WSFUNCTION - AVAILABLE SYSTEM FUNCTIONS (PROGRAMS, FORMS, etc...)
*-----------------------------------------------------------------------*
PROCEDURE cr_wsfunction

REMOVE TABLE WsFunction DELETE
CREATE TABLE WsFunction ;
      (Function   c(15),;
       Descr      c(40),;
       Pgm        c(20),;
       DefPrinter c(30),;
       Type       c(01),;
       Options    c(15))
INDEX ON Function TAG Ident
INDEX ON Descr    TAG Descr
       
=DBSetProp('wsfunction.function'   , 'field', 'caption'     , 'Function code')
=DBSetProp('wsfunction.Descr'      , 'field', 'caption'     , 'Description')
=DBSetProp('wsfunction.Pgm'        , 'field', 'caption'     , 'Program')
=DBSetProp('wsfunction.DefPrinter' , 'field', 'caption'     , 'Default printer')
=DBSetProp('wsfunction.Type'       , 'field', 'caption'     , 'Type')
=DBSetProp('wsfunction.Options'    , 'field', 'caption'     , 'Options')

RETURN

*-----------------------------------------------------------------------*
* WSLANG - LANGUAGES
*-----------------------------------------------------------------------*
PROCEDURE cr_wslang

REMOVE TABLE Wslang DELETE
CREATE TABLE Wslang ;
      (Code       c(02),;
       Descr      c(40))
INDEX ON Descr    TAG Descr
       
RETURN

*-----------------------------------------------------------------------*
* WSTRANSL - TRANSLATION TABLES
*-----------------------------------------------------------------------*
PROCEDURE cr_wstransl

REMOVE TABLE Wstransl DELETE
CREATE TABLE Wstransl ;
      (Code         c(02),;
       Type         c(01),;
       MainObject   c(30),;
       RefObject    c(80),;
       Caption      c(50),;
       ToolTipText  c(50))
INDEX ON Code                 TAG Code
INDEX ON Code+Type+MainObject TAG Main
       
RETURN

*-----------------------------------------------------------------------*
* V1WSPERMIS - VIEW TO INPUT IN WSMGROUP
*-----------------------------------------------------------------------*
PROCEDURE cr_v1wspermis

CREATE SQL VIEW "v1WsPermis" ;
       AS SELECT WsFunction.function,;
                 WsFunction.descr,;
                 .F. AS Acces,;
                 .F. AS Ajout,;
                 .F. AS Modif,;
                 .F. AS Supp,;
                 .F. AS Imp;
                 FROM wsFunction;
                 ORDER BY DESCR

RETURN

*-----------------------------------------------------------------------*
* WSMENU - MENUS 
*-----------------------------------------------------------------------*
PROCEDURE cr_wsmenu

REMOVE TABLE Wsmenu DELETE
CREATE TABLE Wsmenu ;
      (Lang      c(02),;
       Menu      c(10),;
       Order     n(02),;
       Caption   c(50),;
       Type      c(01),;
       Command   c(50))
INDEX ON Lang+Menu TAG Main
       
RETURN

*-----------------------------------------------------------------------*
* WSCIE - company parameters
*-----------------------------------------------------------------------*
PROCEDURE cr_wscie

REMOVE TABLE Wscie DELETE
CREATE TABLE Wscie ;
      (cie_id     i PRIMARY KEY,;
       cie_name   c(40),;
       cie_adr1   c(40),;
       cie_adr2   c(40),;
       cie_city   c(30),;
       cie_state  c(03),;
       cie_zip    c(12),;
       cie_country c(20),;
       cie_tel     c(20),;
       cie_fax     c(20),;
       gl_year     n(04),;
       gl_period   n(02),;
       ar_year     n(04),;
       ar_period   n(02),;
       ap_year     n(04),;
       ap_period   n(02),;
       op_year     n(04),;
       op_period   n(02),;
       gst_rate    n(5,2),;
       pst_rate    n(5,2),;
       nogl_ap     i,;
       nogl_ap_disc i,;
       nogl_ar      i,;
       nogl_ar_disc i,;
       nogl_bq      i,;
       nogl_tps_ach i,;
       nogl_tvq_ach i,;
       nogl_tps_vte i,;
       nogl_tvq_vte i,;
       nogl_bnr     i,;
       nogl_error   i,;
       notps        c(10),;
       notvq        c(10),;
       nb_per_gl    n(02),;
       nb_per_aux   n(02),;
       mailserver   c(50),;
       faxprefix    c(20),;
       currency     c(03),;
       lineout      c(05),;
       cie_lang     c(02),;
       email        c(30),;
       website      c(60),;
       logo         g,;
       logo_prt     g,;
       db_version   i)
       
RETURN
*-----------------------------------------------------------------------*
* WSseq - unique id table
*-----------------------------------------------------------------------*
PROCEDURE cr_wsseq

REMOVE TABLE Wsseq DELETE
CREATE TABLE Wsseq ;
      (Tableid    c(10) PRIMARY KEY,;
       Next_id    i)
       
RETURN

*-----------------------------------------------------------------------*
* WSgroup - user group
*-----------------------------------------------------------------------*
PROCEDURE cr_wsgroup

REMOVE TABLE Wsgroup DELETE
CREATE TABLE Wsgroup ;
      (Code       c(10) PRIMARY KEY,;
       Desc       c(30))

INDEX ON DESC TAG DESC
RETURN

*-----------------------------------------------------------------------*
* WSuser - users
*-----------------------------------------------------------------------*
PROCEDURE cr_wsuser

REMOVE TABLE Wsuser DELETE
CREATE TABLE Wsuser ;
      (Code       c(10) PRIMARY KEY,;
       name       c(30),;
       group      c(10),;
       passwd     c(10),;
       active     l,;
       usertimer  n(02),;
       fbackcolor i,;
       fforecolor i,;
       fdisabledbackcolor i,;
       fdisabledforecolor i,;
       lbackcolor         i,;
       lforecolor         i,;
       ldisabledbackcolor i,;
       ldisabledforecolor i,;
       wbackcolor         i,;
       wforecolor         i,;
       wpicture           c(100),;
       bforecolor         i,;
       bdisabledforecolor i,;
       spicture           c(100),;
       language           c(02),;
       ubar1              c(10),;
       ubar2              c(10),;
       ubar3              c(10),;
       ubar4              c(10),;
       ubar5              c(10),;
       ubar6              c(10),;
       ubar7              c(10),;
       ubar8              c(10),;
       ubar9              c(10),;
       ubar10             c(10),;
       ubarimg1           c(10),;
       ubarimg2           c(10),;
       ubarimg3           c(10),;
       ubarimg4           c(10),;
       ubarimg5           c(10),;
       ubarimg6           c(10),;
       ubarimg7           c(10),;
       ubarimg8           c(10),;
       ubarimg9           c(10),;
       ubarimg10          c(10),;
       type               c(15),;
       sec_level          n(01),;
       canmodclientaccntg l)
       
INDEX ON GROUP TAG GROUP
INDEX ON NAME  TAG NAME       
       
RETURN

*-----------------------------------------------------------------------*
* WSLOG - error log
*-----------------------------------------------------------------------*
PROCEDURE cr_wslog

REMOVE TABLE Wslog DELETE
CREATE TABLE WsloG FREE;
      (Date       d,;
       heure      c(10),;
       user       c(10),;
       module     c(10),;
       type       c(01),;
       desc       c(40),;
       note       m)

INDEX ON DESC TAG DESC
RETURN

* 
* EOF
* 