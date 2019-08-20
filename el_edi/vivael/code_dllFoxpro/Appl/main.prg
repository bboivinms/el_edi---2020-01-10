SET PROCEDURE TO 'wsinit.prg' ADDITIVE
Define Class Main As Session OlePublic

	Procedure Init
	 
	ENDPROC
	   
	PROCEDURE do_init

	ENDPROC
   
   	PROCEDURE ExecuteNonQuery(lcQuery AS String)
		&lcQuery &&  "INSERT INTO wsuer (name) VALUES ('dada')"
	ENDPROC
	
	Function ExecuteQuery(lcQuery AS String, lnNoRec AS Integer, lnCount AS Integer) As String
		SET DELETED ON
		Local lcOut As String
		LOCAL i, j AS Integer
		lcOut = ""
		lcWhere = ""
		
		lcQuery = lcQuery + " INTO CURSOR cur_tempo READWRITE"
		&lcQuery &&  "SELECT * FROM arinv WHERE custid = 30037"
		  
		SELECT cur_tempo 
		GO TOP
		i = 0
		j = 0
		
		DO WHILE !EOF()
			if (i < lnNoRec) THEN
				DELETE
				i = i + 1
			else
			 	IF (j < lnCount OR lnCount = 0 ) THEN
			 		j = j +1 
			 	ELSE
			 		DELETE
			 	ENDIF
			ENDIF
			
			SELECT cur_tempo 
			SKIP
		ENDDO
			
		Cursortoxml("cur_tempo","lcOut",3,0,0,"0")
		Return lcOut

	ENDFUNC

	Function HelloWorld() AS String
		LOCAL lcOut As String
		lcOut = "hello world!"
		
		Return lcOut
	ENDFUNC
	
	
	PROCEDURE WsInit(ptable AS String)
		wsinit(ptable)
	ENDPROC
EndDefine