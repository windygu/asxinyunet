 if exists (select * from sysobjects where id = OBJECT_ID('[llf_sql_test_data]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) DROP TABLE [llf_sql_test_data] 
 CREATE TABLE [llf_sql_test_data] (  [id] [int] IDENTITY (1, 1) NOT NULL , [UserName] [nchar] (50) NULL , [EMail] [char] (100) NULL , [HomePage] [char] (100) NULL )
 ALTER TABLE [llf_sql_test_data] WITH NOCHECK ADD CONSTRAINT [PK_llf_sql_test_data] PRIMARY KEY  NONCLUSTERED ( [id] )

 SET IDENTITY_INSERT [llf_sql_test_data] ON

 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 1 , '0)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 2 , '1)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 3 , '2)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 4 , '3)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 5 , '4)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 6 , '5)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 7 , '6)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 8 , '7)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 9 , '8)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 10 , '9)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 11 , '10)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 12 , '11)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 13 , '12)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 14 , '13)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 15 , '14)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 16 , '15)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 17 , '16)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 18 , '17)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 19 , '18)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 20 , '19)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 21 , '20)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 22 , '21)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 23 , '22)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 24 , '23)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 25 , '24)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 26 , '25)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 27 , '26)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 28 , '27)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 29 , '28)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 30 , '29)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 31 , '30)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 32 , '31)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 33 , '32)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 34 , '33)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 35 , '34)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 36 , '35)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 37 , '36)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 38 , '37)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 39 , '38)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 40 , '39)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 41 , '40)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 42 , '41)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 43 , '42)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 44 , '43)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 45 , '44)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 46 , '45)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 47 , '46)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 48 , '47)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 49 , '48)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 50 , '49)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 51 , '50)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 52 , '51)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 53 , '52)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 54 , '53)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 55 , '54)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 56 , '55)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 57 , '56)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 58 , '57)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 59 , '58)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 60 , '59)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 61 , '60)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 62 , '61)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 63 , '62)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 64 , '63)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 65 , '64)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 66 , '65)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 67 , '66)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 68 , '67)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 69 , '68)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 70 , '69)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 71 , '70)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 72 , '71)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 73 , '72)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 74 , '73)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 75 , '74)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 76 , '75)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 77 , '76)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 78 , '77)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 79 , '78)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 80 , '79)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 81 , '80)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 82 , '81)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 83 , '82)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 84 , '83)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 85 , '84)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 86 , '85)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 87 , '86)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 88 , '87)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 89 , '88)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 90 , '89)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 91 , '90)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 92 , '91)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 93 , '92)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 94 , '93)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 95 , '94)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 96 , '95)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 97 , '96)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 98 , '97)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )
 INSERT [llf_sql_test_data] ( [id] , [UserName] , [EMail] , [HomePage] ) VALUES ( 99 , '98)LiangLifeng' , 'liang_li_feng@tom.com' , 'http://llf.hanzify.org' )

 SET IDENTITY_INSERT [llf_sql_test_data] OFF
GO

CREATE PROCEDURE llf_GetTestData (@PageIndex int, @PageSize int) AS
BEGIN
	DECLARE @PageLowerBound int
	DECLARE @PageUpperBound int

	-- Set the page bounds
	SET @PageLowerBound = @PageSize * @PageIndex
	SET @PageUpperBound = @PageLowerBound + @PageSize + 1

	-- Create a temp table to store the select results
	CREATE TABLE #PageIndexForUsers
	(
		IndexID int IDENTITY (1, 1) NOT NULL,
		id int
	)

	-- Special case depending on what the user wants and how they want it ordered by
	INSERT INTO #PageIndexForUsers (id)
	SELECT id FROM llf_sql_test_data

	-- Get the user details
	SELECT
		U.id,
		UserName,
		EMail,
		HomePage
	FROM
		llf_sql_test_data U (nolock),
		#PageIndexForUsers
	WHERE
		U.id = #PageIndexForUsers.id AND
		#PageIndexForUsers.IndexID > @PageLowerBound AND
		#PageIndexForUsers.IndexID < @PageUpperBound
	ORDER BY
		#PageIndexForUsers.IndexID
END
GO


CREATE PROCEDURE llf_GetOutParam(
	@InParam int,
	@OutParam int output
) AS
BEGIN
	Select @InParam + 1;
	SELECT @OutParam = @InParam + 34;
	return @OutParam - 1;
END

GO
