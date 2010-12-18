
USE [NDMSInvestigation]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionGroup_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionGroup_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionGroup_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the QuestionGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionGroup_Get_List

AS


				
				SELECT
					[GroupId],
					[GroupName],
					[GroupDescription],
					[OrderNumber]
				FROM
					[dbo].[QuestionGroup]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionGroup_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionGroup_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionGroup_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the QuestionGroup table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionGroup_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[GroupId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [GroupId]'
				SET @SQL = @SQL + ', [GroupName]'
				SET @SQL = @SQL + ', [GroupDescription]'
				SET @SQL = @SQL + ', [OrderNumber]'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionGroup]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [GroupId],'
				SET @SQL = @SQL + ' [GroupName],'
				SET @SQL = @SQL + ' [GroupDescription],'
				SET @SQL = @SQL + ' [OrderNumber]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionGroup]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionGroup_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionGroup_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionGroup_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the QuestionGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionGroup_Insert
(

	@GroupId int    OUTPUT,

	@GroupName nvarchar (256)  ,

	@GroupDescription nvarchar (1024)  ,

	@OrderNumber int   
)
AS


				
				INSERT INTO [dbo].[QuestionGroup]
					(
					[GroupName]
					,[GroupDescription]
					,[OrderNumber]
					)
				VALUES
					(
					@GroupName
					,@GroupDescription
					,@OrderNumber
					)
				
				-- Get the identity value
				SET @GroupId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionGroup_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionGroup_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionGroup_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the QuestionGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionGroup_Update
(

	@GroupId int   ,

	@GroupName nvarchar (256)  ,

	@GroupDescription nvarchar (1024)  ,

	@OrderNumber int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[QuestionGroup]
				SET
					[GroupName] = @GroupName
					,[GroupDescription] = @GroupDescription
					,[OrderNumber] = @OrderNumber
				WHERE
[GroupId] = @GroupId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionGroup_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionGroup_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionGroup_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the QuestionGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionGroup_Delete
(

	@GroupId int   
)
AS


				DELETE FROM [dbo].[QuestionGroup] WITH (ROWLOCK) 
				WHERE
					[GroupId] = @GroupId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionGroup_GetByOrderNumber procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionGroup_GetByOrderNumber') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionGroup_GetByOrderNumber
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the QuestionGroup table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionGroup_GetByOrderNumber
(

	@OrderNumber int   
)
AS


				SELECT
					[GroupId],
					[GroupName],
					[GroupDescription],
					[OrderNumber]
				FROM
					[dbo].[QuestionGroup]
				WHERE
					[OrderNumber] = @OrderNumber
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionGroup_GetByGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionGroup_GetByGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionGroup_GetByGroupId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the QuestionGroup table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionGroup_GetByGroupId
(

	@GroupId int   
)
AS


				SELECT
					[GroupId],
					[GroupName],
					[GroupDescription],
					[OrderNumber]
				FROM
					[dbo].[QuestionGroup]
				WHERE
					[GroupId] = @GroupId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionGroup_GetByUserIdFromResult procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionGroup_GetByUserIdFromResult') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionGroup_GetByUserIdFromResult
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionGroup_GetByUserIdFromResult
(

	@UserId uniqueidentifier   
)
AS


SELECT dbo.[QuestionGroup].[GroupId]
       ,dbo.[QuestionGroup].[GroupName]
       ,dbo.[QuestionGroup].[GroupDescription]
       ,dbo.[QuestionGroup].[OrderNumber]
  FROM dbo.[QuestionGroup]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[Result] 
                WHERE dbo.[Result].[UserId] = @UserId
                  AND dbo.[Result].[GroupId] = dbo.[QuestionGroup].[GroupId]
                  )
				SELECT @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionGroup_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionGroup_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionGroup_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the QuestionGroup table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionGroup_Find
(

	@SearchUsingOR bit   = null ,

	@GroupId int   = null ,

	@GroupName nvarchar (256)  = null ,

	@GroupDescription nvarchar (1024)  = null ,

	@OrderNumber int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [GroupId]
	, [GroupName]
	, [GroupDescription]
	, [OrderNumber]
    FROM
	[dbo].[QuestionGroup]
    WHERE 
	 ([GroupId] = @GroupId OR @GroupId IS NULL)
	AND ([GroupName] = @GroupName OR @GroupName IS NULL)
	AND ([GroupDescription] = @GroupDescription OR @GroupDescription IS NULL)
	AND ([OrderNumber] = @OrderNumber OR @OrderNumber IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [GroupId]
	, [GroupName]
	, [GroupDescription]
	, [OrderNumber]
    FROM
	[dbo].[QuestionGroup]
    WHERE 
	 ([GroupId] = @GroupId AND @GroupId is not null)
	OR ([GroupName] = @GroupName AND @GroupName is not null)
	OR ([GroupDescription] = @GroupDescription AND @GroupDescription is not null)
	OR ([OrderNumber] = @OrderNumber AND @OrderNumber is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AnswerDetails_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AnswerDetails_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AnswerDetails_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the AnswerDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AnswerDetails_Get_List

AS


				
				SELECT
					[AnswerId],
					[AnswerContent],
					[AnswerMark],
					[AnswerDescription]
				FROM
					[dbo].[AnswerDetails]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AnswerDetails_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AnswerDetails_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AnswerDetails_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the AnswerDetails table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AnswerDetails_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[AnswerId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [AnswerId]'
				SET @SQL = @SQL + ', [AnswerContent]'
				SET @SQL = @SQL + ', [AnswerMark]'
				SET @SQL = @SQL + ', [AnswerDescription]'
				SET @SQL = @SQL + ' FROM [dbo].[AnswerDetails]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AnswerId],'
				SET @SQL = @SQL + ' [AnswerContent],'
				SET @SQL = @SQL + ' [AnswerMark],'
				SET @SQL = @SQL + ' [AnswerDescription]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[AnswerDetails]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AnswerDetails_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AnswerDetails_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AnswerDetails_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the AnswerDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AnswerDetails_Insert
(

	@AnswerId int    OUTPUT,

	@AnswerContent nchar (512)  ,

	@AnswerMark int   ,

	@AnswerDescription nvarchar (1024)  
)
AS


				
				INSERT INTO [dbo].[AnswerDetails]
					(
					[AnswerContent]
					,[AnswerMark]
					,[AnswerDescription]
					)
				VALUES
					(
					@AnswerContent
					,@AnswerMark
					,@AnswerDescription
					)
				
				-- Get the identity value
				SET @AnswerId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AnswerDetails_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AnswerDetails_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AnswerDetails_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the AnswerDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AnswerDetails_Update
(

	@AnswerId int   ,

	@AnswerContent nchar (512)  ,

	@AnswerMark int   ,

	@AnswerDescription nvarchar (1024)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[AnswerDetails]
				SET
					[AnswerContent] = @AnswerContent
					,[AnswerMark] = @AnswerMark
					,[AnswerDescription] = @AnswerDescription
				WHERE
[AnswerId] = @AnswerId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AnswerDetails_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AnswerDetails_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AnswerDetails_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the AnswerDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AnswerDetails_Delete
(

	@AnswerId int   
)
AS


				DELETE FROM [dbo].[AnswerDetails] WITH (ROWLOCK) 
				WHERE
					[AnswerId] = @AnswerId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AnswerDetails_GetByAnswerId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AnswerDetails_GetByAnswerId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AnswerDetails_GetByAnswerId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the AnswerDetails table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AnswerDetails_GetByAnswerId
(

	@AnswerId int   
)
AS


				SELECT
					[AnswerId],
					[AnswerContent],
					[AnswerMark],
					[AnswerDescription]
				FROM
					[dbo].[AnswerDetails]
				WHERE
					[AnswerId] = @AnswerId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AnswerDetails_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AnswerDetails_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AnswerDetails_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the AnswerDetails table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AnswerDetails_Find
(

	@SearchUsingOR bit   = null ,

	@AnswerId int   = null ,

	@AnswerContent nchar (512)  = null ,

	@AnswerMark int   = null ,

	@AnswerDescription nvarchar (1024)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AnswerId]
	, [AnswerContent]
	, [AnswerMark]
	, [AnswerDescription]
    FROM
	[dbo].[AnswerDetails]
    WHERE 
	 ([AnswerId] = @AnswerId OR @AnswerId IS NULL)
	AND ([AnswerContent] = @AnswerContent OR @AnswerContent IS NULL)
	AND ([AnswerMark] = @AnswerMark OR @AnswerMark IS NULL)
	AND ([AnswerDescription] = @AnswerDescription OR @AnswerDescription IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AnswerId]
	, [AnswerContent]
	, [AnswerMark]
	, [AnswerDescription]
    FROM
	[dbo].[AnswerDetails]
    WHERE 
	 ([AnswerId] = @AnswerId AND @AnswerId is not null)
	OR ([AnswerContent] = @AnswerContent AND @AnswerContent is not null)
	OR ([AnswerMark] = @AnswerMark AND @AnswerMark is not null)
	OR ([AnswerDescription] = @AnswerDescription AND @AnswerDescription is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_WebEvent_Events_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_WebEvent_Events_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_WebEvent_Events_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the aspnet_WebEvent_Events table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_WebEvent_Events_Get_List

AS


				
				SELECT
					[EventId],
					[EventTimeUtc],
					[EventTime],
					[EventType],
					[EventSequence],
					[EventOccurrence],
					[EventCode],
					[EventDetailCode],
					[Message],
					[ApplicationPath],
					[ApplicationVirtualPath],
					[MachineName],
					[RequestUrl],
					[ExceptionType],
					[Details]
				FROM
					[dbo].[aspnet_WebEvent_Events]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_WebEvent_Events_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_WebEvent_Events_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_WebEvent_Events_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the aspnet_WebEvent_Events table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_WebEvent_Events_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[EventId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [EventId]'
				SET @SQL = @SQL + ', [EventTimeUtc]'
				SET @SQL = @SQL + ', [EventTime]'
				SET @SQL = @SQL + ', [EventType]'
				SET @SQL = @SQL + ', [EventSequence]'
				SET @SQL = @SQL + ', [EventOccurrence]'
				SET @SQL = @SQL + ', [EventCode]'
				SET @SQL = @SQL + ', [EventDetailCode]'
				SET @SQL = @SQL + ', [Message]'
				SET @SQL = @SQL + ', [ApplicationPath]'
				SET @SQL = @SQL + ', [ApplicationVirtualPath]'
				SET @SQL = @SQL + ', [MachineName]'
				SET @SQL = @SQL + ', [RequestUrl]'
				SET @SQL = @SQL + ', [ExceptionType]'
				SET @SQL = @SQL + ', [Details]'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_WebEvent_Events]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [EventId],'
				SET @SQL = @SQL + ' [EventTimeUtc],'
				SET @SQL = @SQL + ' [EventTime],'
				SET @SQL = @SQL + ' [EventType],'
				SET @SQL = @SQL + ' [EventSequence],'
				SET @SQL = @SQL + ' [EventOccurrence],'
				SET @SQL = @SQL + ' [EventCode],'
				SET @SQL = @SQL + ' [EventDetailCode],'
				SET @SQL = @SQL + ' [Message],'
				SET @SQL = @SQL + ' [ApplicationPath],'
				SET @SQL = @SQL + ' [ApplicationVirtualPath],'
				SET @SQL = @SQL + ' [MachineName],'
				SET @SQL = @SQL + ' [RequestUrl],'
				SET @SQL = @SQL + ' [ExceptionType],'
				SET @SQL = @SQL + ' [Details]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_WebEvent_Events]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_WebEvent_Events_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_WebEvent_Events_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_WebEvent_Events_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the aspnet_WebEvent_Events table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_WebEvent_Events_Insert
(

	@EventId char (32)  ,

	@EventTimeUtc datetime   ,

	@EventTime datetime   ,

	@EventType nvarchar (256)  ,

	@EventSequence decimal (19, 0)  ,

	@EventOccurrence decimal (19, 0)  ,

	@EventCode int   ,

	@EventDetailCode int   ,

	@Message nvarchar (1024)  ,

	@ApplicationPath nvarchar (256)  ,

	@ApplicationVirtualPath nvarchar (256)  ,

	@MachineName nvarchar (256)  ,

	@RequestUrl nvarchar (1024)  ,

	@ExceptionType nvarchar (256)  ,

	@Details ntext   
)
AS


				
				INSERT INTO [dbo].[aspnet_WebEvent_Events]
					(
					[EventId]
					,[EventTimeUtc]
					,[EventTime]
					,[EventType]
					,[EventSequence]
					,[EventOccurrence]
					,[EventCode]
					,[EventDetailCode]
					,[Message]
					,[ApplicationPath]
					,[ApplicationVirtualPath]
					,[MachineName]
					,[RequestUrl]
					,[ExceptionType]
					,[Details]
					)
				VALUES
					(
					@EventId
					,@EventTimeUtc
					,@EventTime
					,@EventType
					,@EventSequence
					,@EventOccurrence
					,@EventCode
					,@EventDetailCode
					,@Message
					,@ApplicationPath
					,@ApplicationVirtualPath
					,@MachineName
					,@RequestUrl
					,@ExceptionType
					,@Details
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_WebEvent_Events_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_WebEvent_Events_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_WebEvent_Events_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the aspnet_WebEvent_Events table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_WebEvent_Events_Update
(

	@EventId char (32)  ,

	@OriginalEventId char (32)  ,

	@EventTimeUtc datetime   ,

	@EventTime datetime   ,

	@EventType nvarchar (256)  ,

	@EventSequence decimal (19, 0)  ,

	@EventOccurrence decimal (19, 0)  ,

	@EventCode int   ,

	@EventDetailCode int   ,

	@Message nvarchar (1024)  ,

	@ApplicationPath nvarchar (256)  ,

	@ApplicationVirtualPath nvarchar (256)  ,

	@MachineName nvarchar (256)  ,

	@RequestUrl nvarchar (1024)  ,

	@ExceptionType nvarchar (256)  ,

	@Details ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[aspnet_WebEvent_Events]
				SET
					[EventId] = @EventId
					,[EventTimeUtc] = @EventTimeUtc
					,[EventTime] = @EventTime
					,[EventType] = @EventType
					,[EventSequence] = @EventSequence
					,[EventOccurrence] = @EventOccurrence
					,[EventCode] = @EventCode
					,[EventDetailCode] = @EventDetailCode
					,[Message] = @Message
					,[ApplicationPath] = @ApplicationPath
					,[ApplicationVirtualPath] = @ApplicationVirtualPath
					,[MachineName] = @MachineName
					,[RequestUrl] = @RequestUrl
					,[ExceptionType] = @ExceptionType
					,[Details] = @Details
				WHERE
[EventId] = @OriginalEventId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_WebEvent_Events_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_WebEvent_Events_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_WebEvent_Events_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the aspnet_WebEvent_Events table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_WebEvent_Events_Delete
(

	@EventId char (32)  
)
AS


				DELETE FROM [dbo].[aspnet_WebEvent_Events] WITH (ROWLOCK) 
				WHERE
					[EventId] = @EventId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_WebEvent_Events_GetByEventId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_WebEvent_Events_GetByEventId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_WebEvent_Events_GetByEventId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_WebEvent_Events table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_WebEvent_Events_GetByEventId
(

	@EventId char (32)  
)
AS


				SELECT
					[EventId],
					[EventTimeUtc],
					[EventTime],
					[EventType],
					[EventSequence],
					[EventOccurrence],
					[EventCode],
					[EventDetailCode],
					[Message],
					[ApplicationPath],
					[ApplicationVirtualPath],
					[MachineName],
					[RequestUrl],
					[ExceptionType],
					[Details]
				FROM
					[dbo].[aspnet_WebEvent_Events]
				WHERE
					[EventId] = @EventId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_WebEvent_Events_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_WebEvent_Events_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_WebEvent_Events_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the aspnet_WebEvent_Events table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_WebEvent_Events_Find
(

	@SearchUsingOR bit   = null ,

	@EventId char (32)  = null ,

	@EventTimeUtc datetime   = null ,

	@EventTime datetime   = null ,

	@EventType nvarchar (256)  = null ,

	@EventSequence decimal (19, 0)  = null ,

	@EventOccurrence decimal (19, 0)  = null ,

	@EventCode int   = null ,

	@EventDetailCode int   = null ,

	@Message nvarchar (1024)  = null ,

	@ApplicationPath nvarchar (256)  = null ,

	@ApplicationVirtualPath nvarchar (256)  = null ,

	@MachineName nvarchar (256)  = null ,

	@RequestUrl nvarchar (1024)  = null ,

	@ExceptionType nvarchar (256)  = null ,

	@Details ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [EventId]
	, [EventTimeUtc]
	, [EventTime]
	, [EventType]
	, [EventSequence]
	, [EventOccurrence]
	, [EventCode]
	, [EventDetailCode]
	, [Message]
	, [ApplicationPath]
	, [ApplicationVirtualPath]
	, [MachineName]
	, [RequestUrl]
	, [ExceptionType]
	, [Details]
    FROM
	[dbo].[aspnet_WebEvent_Events]
    WHERE 
	 ([EventId] = @EventId OR @EventId IS NULL)
	AND ([EventTimeUtc] = @EventTimeUtc OR @EventTimeUtc IS NULL)
	AND ([EventTime] = @EventTime OR @EventTime IS NULL)
	AND ([EventType] = @EventType OR @EventType IS NULL)
	AND ([EventSequence] = @EventSequence OR @EventSequence IS NULL)
	AND ([EventOccurrence] = @EventOccurrence OR @EventOccurrence IS NULL)
	AND ([EventCode] = @EventCode OR @EventCode IS NULL)
	AND ([EventDetailCode] = @EventDetailCode OR @EventDetailCode IS NULL)
	AND ([Message] = @Message OR @Message IS NULL)
	AND ([ApplicationPath] = @ApplicationPath OR @ApplicationPath IS NULL)
	AND ([ApplicationVirtualPath] = @ApplicationVirtualPath OR @ApplicationVirtualPath IS NULL)
	AND ([MachineName] = @MachineName OR @MachineName IS NULL)
	AND ([RequestUrl] = @RequestUrl OR @RequestUrl IS NULL)
	AND ([ExceptionType] = @ExceptionType OR @ExceptionType IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [EventId]
	, [EventTimeUtc]
	, [EventTime]
	, [EventType]
	, [EventSequence]
	, [EventOccurrence]
	, [EventCode]
	, [EventDetailCode]
	, [Message]
	, [ApplicationPath]
	, [ApplicationVirtualPath]
	, [MachineName]
	, [RequestUrl]
	, [ExceptionType]
	, [Details]
    FROM
	[dbo].[aspnet_WebEvent_Events]
    WHERE 
	 ([EventId] = @EventId AND @EventId is not null)
	OR ([EventTimeUtc] = @EventTimeUtc AND @EventTimeUtc is not null)
	OR ([EventTime] = @EventTime AND @EventTime is not null)
	OR ([EventType] = @EventType AND @EventType is not null)
	OR ([EventSequence] = @EventSequence AND @EventSequence is not null)
	OR ([EventOccurrence] = @EventOccurrence AND @EventOccurrence is not null)
	OR ([EventCode] = @EventCode AND @EventCode is not null)
	OR ([EventDetailCode] = @EventDetailCode AND @EventDetailCode is not null)
	OR ([Message] = @Message AND @Message is not null)
	OR ([ApplicationPath] = @ApplicationPath AND @ApplicationPath is not null)
	OR ([ApplicationVirtualPath] = @ApplicationVirtualPath AND @ApplicationVirtualPath is not null)
	OR ([MachineName] = @MachineName AND @MachineName is not null)
	OR ([RequestUrl] = @RequestUrl AND @RequestUrl is not null)
	OR ([ExceptionType] = @ExceptionType AND @ExceptionType is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_UsersInRoles_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_UsersInRoles_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_UsersInRoles_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the aspnet_UsersInRoles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_UsersInRoles_Get_List

AS


				
				SELECT
					[UserId],
					[RoleId]
				FROM
					[dbo].[aspnet_UsersInRoles]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_UsersInRoles_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_UsersInRoles_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_UsersInRoles_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the aspnet_UsersInRoles table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_UsersInRoles_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[UserId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [UserId]'
				SET @SQL = @SQL + ', [RoleId]'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_UsersInRoles]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [UserId],'
				SET @SQL = @SQL + ' [RoleId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_UsersInRoles]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_UsersInRoles_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_UsersInRoles_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_UsersInRoles_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the aspnet_UsersInRoles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_UsersInRoles_Insert
(

	@UserId uniqueidentifier   ,

	@RoleId uniqueidentifier   
)
AS


				
				INSERT INTO [dbo].[aspnet_UsersInRoles]
					(
					[UserId]
					,[RoleId]
					)
				VALUES
					(
					@UserId
					,@RoleId
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_UsersInRoles_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_UsersInRoles_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_UsersInRoles_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the aspnet_UsersInRoles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_UsersInRoles_Update
(

	@UserId uniqueidentifier   ,

	@OriginalUserId uniqueidentifier   ,

	@RoleId uniqueidentifier   ,

	@OriginalRoleId uniqueidentifier   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[aspnet_UsersInRoles]
				SET
					[UserId] = @UserId
					,[RoleId] = @RoleId
				WHERE
[UserId] = @OriginalUserId 
AND [RoleId] = @OriginalRoleId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_UsersInRoles_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_UsersInRoles_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_UsersInRoles_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the aspnet_UsersInRoles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_UsersInRoles_Delete
(

	@UserId uniqueidentifier   ,

	@RoleId uniqueidentifier   
)
AS


				DELETE FROM [dbo].[aspnet_UsersInRoles] WITH (ROWLOCK) 
				WHERE
					[UserId] = @UserId
					AND [RoleId] = @RoleId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_UsersInRoles_GetByUserId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_UsersInRoles_GetByUserId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_UsersInRoles_GetByUserId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_UsersInRoles table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_UsersInRoles_GetByUserId
(

	@UserId uniqueidentifier   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[UserId],
					[RoleId]
				FROM
					[dbo].[aspnet_UsersInRoles]
				WHERE
					[UserId] = @UserId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_UsersInRoles_GetByRoleId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_UsersInRoles_GetByRoleId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_UsersInRoles_GetByRoleId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_UsersInRoles table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_UsersInRoles_GetByRoleId
(

	@RoleId uniqueidentifier   
)
AS


				SELECT
					[UserId],
					[RoleId]
				FROM
					[dbo].[aspnet_UsersInRoles]
				WHERE
					[RoleId] = @RoleId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_UsersInRoles_GetByUserIdRoleId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_UsersInRoles_GetByUserIdRoleId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_UsersInRoles_GetByUserIdRoleId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_UsersInRoles table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_UsersInRoles_GetByUserIdRoleId
(

	@UserId uniqueidentifier   ,

	@RoleId uniqueidentifier   
)
AS


				SELECT
					[UserId],
					[RoleId]
				FROM
					[dbo].[aspnet_UsersInRoles]
				WHERE
					[UserId] = @UserId
					AND [RoleId] = @RoleId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_UsersInRoles_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_UsersInRoles_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_UsersInRoles_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the aspnet_UsersInRoles table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_UsersInRoles_Find
(

	@SearchUsingOR bit   = null ,

	@UserId uniqueidentifier   = null ,

	@RoleId uniqueidentifier   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [UserId]
	, [RoleId]
    FROM
	[dbo].[aspnet_UsersInRoles]
    WHERE 
	 ([UserId] = @UserId OR @UserId IS NULL)
	AND ([RoleId] = @RoleId OR @RoleId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [UserId]
	, [RoleId]
    FROM
	[dbo].[aspnet_UsersInRoles]
    WHERE 
	 ([UserId] = @UserId AND @UserId is not null)
	OR ([RoleId] = @RoleId AND @RoleId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Result_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Result_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Result_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the Result table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Result_Get_List

AS


				
				SELECT
					[UserId],
					[GroupId],
					[GroupMark],
					[UpdateDay]
				FROM
					[dbo].[Result]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Result_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Result_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Result_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the Result table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Result_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[UserId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [UserId]'
				SET @SQL = @SQL + ', [GroupId]'
				SET @SQL = @SQL + ', [GroupMark]'
				SET @SQL = @SQL + ', [UpdateDay]'
				SET @SQL = @SQL + ' FROM [dbo].[Result]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [UserId],'
				SET @SQL = @SQL + ' [GroupId],'
				SET @SQL = @SQL + ' [GroupMark],'
				SET @SQL = @SQL + ' [UpdateDay]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Result]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Result_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Result_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Result_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the Result table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Result_Insert
(

	@UserId uniqueidentifier   ,

	@GroupId int   ,

	@GroupMark int   ,

	@UpdateDay datetime   
)
AS


				
				INSERT INTO [dbo].[Result]
					(
					[UserId]
					,[GroupId]
					,[GroupMark]
					,[UpdateDay]
					)
				VALUES
					(
					@UserId
					,@GroupId
					,@GroupMark
					,@UpdateDay
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Result_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Result_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Result_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the Result table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Result_Update
(

	@UserId uniqueidentifier   ,

	@OriginalUserId uniqueidentifier   ,

	@GroupId int   ,

	@OriginalGroupId int   ,

	@GroupMark int   ,

	@UpdateDay datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Result]
				SET
					[UserId] = @UserId
					,[GroupId] = @GroupId
					,[GroupMark] = @GroupMark
					,[UpdateDay] = @UpdateDay
				WHERE
[UserId] = @OriginalUserId 
AND [GroupId] = @OriginalGroupId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Result_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Result_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Result_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the Result table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Result_Delete
(

	@UserId uniqueidentifier   ,

	@GroupId int   
)
AS


				DELETE FROM [dbo].[Result] WITH (ROWLOCK) 
				WHERE
					[UserId] = @UserId
					AND [GroupId] = @GroupId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Result_GetByUserId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Result_GetByUserId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Result_GetByUserId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the Result table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Result_GetByUserId
(

	@UserId uniqueidentifier   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[UserId],
					[GroupId],
					[GroupMark],
					[UpdateDay]
				FROM
					[dbo].[Result]
				WHERE
					[UserId] = @UserId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Result_GetByGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Result_GetByGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Result_GetByGroupId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the Result table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Result_GetByGroupId
(

	@GroupId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[UserId],
					[GroupId],
					[GroupMark],
					[UpdateDay]
				FROM
					[dbo].[Result]
				WHERE
					[GroupId] = @GroupId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Result_GetByUserIdGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Result_GetByUserIdGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Result_GetByUserIdGroupId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the Result table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Result_GetByUserIdGroupId
(

	@UserId uniqueidentifier   ,

	@GroupId int   
)
AS


				SELECT
					[UserId],
					[GroupId],
					[GroupMark],
					[UpdateDay]
				FROM
					[dbo].[Result]
				WHERE
					[UserId] = @UserId
					AND [GroupId] = @GroupId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Result_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Result_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Result_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the Result table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Result_Find
(

	@SearchUsingOR bit   = null ,

	@UserId uniqueidentifier   = null ,

	@GroupId int   = null ,

	@GroupMark int   = null ,

	@UpdateDay datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [UserId]
	, [GroupId]
	, [GroupMark]
	, [UpdateDay]
    FROM
	[dbo].[Result]
    WHERE 
	 ([UserId] = @UserId OR @UserId IS NULL)
	AND ([GroupId] = @GroupId OR @GroupId IS NULL)
	AND ([GroupMark] = @GroupMark OR @GroupMark IS NULL)
	AND ([UpdateDay] = @UpdateDay OR @UpdateDay IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [UserId]
	, [GroupId]
	, [GroupMark]
	, [UpdateDay]
    FROM
	[dbo].[Result]
    WHERE 
	 ([UserId] = @UserId AND @UserId is not null)
	OR ([GroupId] = @GroupId AND @GroupId is not null)
	OR ([GroupMark] = @GroupMark AND @GroupMark is not null)
	OR ([UpdateDay] = @UpdateDay AND @UpdateDay is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionDetails_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionDetails_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionDetails_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the QuestionDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionDetails_Get_List

AS


				
				SELECT
					[QuestionId],
					[QuestionContent],
					[QuestionSuggest],
					[QuestionDescription],
					[GroupId],
					[OrderNumber]
				FROM
					[dbo].[QuestionDetails]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionDetails_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionDetails_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionDetails_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the QuestionDetails table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionDetails_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[QuestionId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [QuestionId]'
				SET @SQL = @SQL + ', [QuestionContent]'
				SET @SQL = @SQL + ', [QuestionSuggest]'
				SET @SQL = @SQL + ', [QuestionDescription]'
				SET @SQL = @SQL + ', [GroupId]'
				SET @SQL = @SQL + ', [OrderNumber]'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionDetails]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [QuestionId],'
				SET @SQL = @SQL + ' [QuestionContent],'
				SET @SQL = @SQL + ' [QuestionSuggest],'
				SET @SQL = @SQL + ' [QuestionDescription],'
				SET @SQL = @SQL + ' [GroupId],'
				SET @SQL = @SQL + ' [OrderNumber]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[QuestionDetails]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionDetails_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionDetails_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionDetails_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the QuestionDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionDetails_Insert
(

	@QuestionId int    OUTPUT,

	@QuestionContent nvarchar (512)  ,

	@QuestionSuggest nvarchar (1024)  ,

	@QuestionDescription nvarchar (1024)  ,

	@GroupId int   ,

	@OrderNumber int   
)
AS


				
				INSERT INTO [dbo].[QuestionDetails]
					(
					[QuestionContent]
					,[QuestionSuggest]
					,[QuestionDescription]
					,[GroupId]
					,[OrderNumber]
					)
				VALUES
					(
					@QuestionContent
					,@QuestionSuggest
					,@QuestionDescription
					,@GroupId
					,@OrderNumber
					)
				
				-- Get the identity value
				SET @QuestionId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionDetails_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionDetails_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionDetails_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the QuestionDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionDetails_Update
(

	@QuestionId int   ,

	@QuestionContent nvarchar (512)  ,

	@QuestionSuggest nvarchar (1024)  ,

	@QuestionDescription nvarchar (1024)  ,

	@GroupId int   ,

	@OrderNumber int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[QuestionDetails]
				SET
					[QuestionContent] = @QuestionContent
					,[QuestionSuggest] = @QuestionSuggest
					,[QuestionDescription] = @QuestionDescription
					,[GroupId] = @GroupId
					,[OrderNumber] = @OrderNumber
				WHERE
[QuestionId] = @QuestionId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionDetails_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionDetails_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionDetails_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the QuestionDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionDetails_Delete
(

	@QuestionId int   
)
AS


				DELETE FROM [dbo].[QuestionDetails] WITH (ROWLOCK) 
				WHERE
					[QuestionId] = @QuestionId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionDetails_GetByGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionDetails_GetByGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionDetails_GetByGroupId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the QuestionDetails table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionDetails_GetByGroupId
(

	@GroupId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[QuestionId],
					[QuestionContent],
					[QuestionSuggest],
					[QuestionDescription],
					[GroupId],
					[OrderNumber]
				FROM
					[dbo].[QuestionDetails]
				WHERE
					[GroupId] = @GroupId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionDetails_GetByGroupIdOrderNumber procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionDetails_GetByGroupIdOrderNumber') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionDetails_GetByGroupIdOrderNumber
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the QuestionDetails table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionDetails_GetByGroupIdOrderNumber
(

	@GroupId int   ,

	@OrderNumber int   
)
AS


				SELECT
					[QuestionId],
					[QuestionContent],
					[QuestionSuggest],
					[QuestionDescription],
					[GroupId],
					[OrderNumber]
				FROM
					[dbo].[QuestionDetails]
				WHERE
					[GroupId] = @GroupId
					AND [OrderNumber] = @OrderNumber
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionDetails_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionDetails_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionDetails_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the QuestionDetails table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionDetails_GetByQuestionId
(

	@QuestionId int   
)
AS


				SELECT
					[QuestionId],
					[QuestionContent],
					[QuestionSuggest],
					[QuestionDescription],
					[GroupId],
					[OrderNumber]
				FROM
					[dbo].[QuestionDetails]
				WHERE
					[QuestionId] = @QuestionId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuestionDetails_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuestionDetails_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuestionDetails_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the QuestionDetails table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuestionDetails_Find
(

	@SearchUsingOR bit   = null ,

	@QuestionId int   = null ,

	@QuestionContent nvarchar (512)  = null ,

	@QuestionSuggest nvarchar (1024)  = null ,

	@QuestionDescription nvarchar (1024)  = null ,

	@GroupId int   = null ,

	@OrderNumber int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [QuestionId]
	, [QuestionContent]
	, [QuestionSuggest]
	, [QuestionDescription]
	, [GroupId]
	, [OrderNumber]
    FROM
	[dbo].[QuestionDetails]
    WHERE 
	 ([QuestionId] = @QuestionId OR @QuestionId IS NULL)
	AND ([QuestionContent] = @QuestionContent OR @QuestionContent IS NULL)
	AND ([QuestionSuggest] = @QuestionSuggest OR @QuestionSuggest IS NULL)
	AND ([QuestionDescription] = @QuestionDescription OR @QuestionDescription IS NULL)
	AND ([GroupId] = @GroupId OR @GroupId IS NULL)
	AND ([OrderNumber] = @OrderNumber OR @OrderNumber IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [QuestionId]
	, [QuestionContent]
	, [QuestionSuggest]
	, [QuestionDescription]
	, [GroupId]
	, [OrderNumber]
    FROM
	[dbo].[QuestionDetails]
    WHERE 
	 ([QuestionId] = @QuestionId AND @QuestionId is not null)
	OR ([QuestionContent] = @QuestionContent AND @QuestionContent is not null)
	OR ([QuestionSuggest] = @QuestionSuggest AND @QuestionSuggest is not null)
	OR ([QuestionDescription] = @QuestionDescription AND @QuestionDescription is not null)
	OR ([GroupId] = @GroupId AND @GroupId is not null)
	OR ([OrderNumber] = @OrderNumber AND @OrderNumber is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Question_Answer_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Question_Answer_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Question_Answer_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the Question_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Question_Answer_Get_List

AS


				
				SELECT
					[QuestionId],
					[AnswerId],
					[Mark],
					[Question_AnswerId]
				FROM
					[dbo].[Question_Answer]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Question_Answer_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Question_Answer_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Question_Answer_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the Question_Answer table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Question_Answer_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[QuestionId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [QuestionId]'
				SET @SQL = @SQL + ', [AnswerId]'
				SET @SQL = @SQL + ', [Mark]'
				SET @SQL = @SQL + ', [Question_AnswerId]'
				SET @SQL = @SQL + ' FROM [dbo].[Question_Answer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [QuestionId],'
				SET @SQL = @SQL + ' [AnswerId],'
				SET @SQL = @SQL + ' [Mark],'
				SET @SQL = @SQL + ' [Question_AnswerId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Question_Answer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Question_Answer_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Question_Answer_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Question_Answer_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the Question_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Question_Answer_Insert
(

	@QuestionId int   ,

	@AnswerId int   ,

	@Mark int   ,

	@QuestionAnswerId int    OUTPUT
)
AS


				
				INSERT INTO [dbo].[Question_Answer]
					(
					[QuestionId]
					,[AnswerId]
					,[Mark]
					)
				VALUES
					(
					@QuestionId
					,@AnswerId
					,@Mark
					)
				
				-- Get the identity value
				SET @QuestionAnswerId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Question_Answer_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Question_Answer_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Question_Answer_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the Question_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Question_Answer_Update
(

	@QuestionId int   ,

	@AnswerId int   ,

	@Mark int   ,

	@QuestionAnswerId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Question_Answer]
				SET
					[QuestionId] = @QuestionId
					,[AnswerId] = @AnswerId
					,[Mark] = @Mark
				WHERE
[Question_AnswerId] = @QuestionAnswerId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Question_Answer_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Question_Answer_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Question_Answer_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the Question_Answer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Question_Answer_Delete
(

	@QuestionAnswerId int   
)
AS


				DELETE FROM [dbo].[Question_Answer] WITH (ROWLOCK) 
				WHERE
					[Question_AnswerId] = @QuestionAnswerId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Question_Answer_GetByAnswerId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Question_Answer_GetByAnswerId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Question_Answer_GetByAnswerId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the Question_Answer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Question_Answer_GetByAnswerId
(

	@AnswerId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[QuestionId],
					[AnswerId],
					[Mark],
					[Question_AnswerId]
				FROM
					[dbo].[Question_Answer]
				WHERE
					[AnswerId] = @AnswerId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Question_Answer_GetByQuestionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Question_Answer_GetByQuestionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Question_Answer_GetByQuestionId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the Question_Answer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Question_Answer_GetByQuestionId
(

	@QuestionId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[QuestionId],
					[AnswerId],
					[Mark],
					[Question_AnswerId]
				FROM
					[dbo].[Question_Answer]
				WHERE
					[QuestionId] = @QuestionId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Question_Answer_GetByQuestionAnswerId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Question_Answer_GetByQuestionAnswerId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Question_Answer_GetByQuestionAnswerId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the Question_Answer table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Question_Answer_GetByQuestionAnswerId
(

	@QuestionAnswerId int   
)
AS


				SELECT
					[QuestionId],
					[AnswerId],
					[Mark],
					[Question_AnswerId]
				FROM
					[dbo].[Question_Answer]
				WHERE
					[Question_AnswerId] = @QuestionAnswerId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Question_Answer_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Question_Answer_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Question_Answer_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the Question_Answer table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Question_Answer_Find
(

	@SearchUsingOR bit   = null ,

	@QuestionId int   = null ,

	@AnswerId int   = null ,

	@Mark int   = null ,

	@QuestionAnswerId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [QuestionId]
	, [AnswerId]
	, [Mark]
	, [Question_AnswerId]
    FROM
	[dbo].[Question_Answer]
    WHERE 
	 ([QuestionId] = @QuestionId OR @QuestionId IS NULL)
	AND ([AnswerId] = @AnswerId OR @AnswerId IS NULL)
	AND ([Mark] = @Mark OR @Mark IS NULL)
	AND ([Question_AnswerId] = @QuestionAnswerId OR @QuestionAnswerId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [QuestionId]
	, [AnswerId]
	, [Mark]
	, [Question_AnswerId]
    FROM
	[dbo].[Question_Answer]
    WHERE 
	 ([QuestionId] = @QuestionId AND @QuestionId is not null)
	OR ([AnswerId] = @AnswerId AND @AnswerId is not null)
	OR ([Mark] = @Mark AND @Mark is not null)
	OR ([Question_AnswerId] = @QuestionAnswerId AND @QuestionAnswerId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Users_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Users_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Users_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the aspnet_Users table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Users_Get_List

AS


				
				SELECT
					[ApplicationId],
					[UserId],
					[UserName],
					[LoweredUserName],
					[MobileAlias],
					[IsAnonymous],
					[LastActivityDate]
				FROM
					[dbo].[aspnet_Users]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Users_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Users_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Users_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the aspnet_Users table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Users_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ApplicationId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ApplicationId]'
				SET @SQL = @SQL + ', [UserId]'
				SET @SQL = @SQL + ', [UserName]'
				SET @SQL = @SQL + ', [LoweredUserName]'
				SET @SQL = @SQL + ', [MobileAlias]'
				SET @SQL = @SQL + ', [IsAnonymous]'
				SET @SQL = @SQL + ', [LastActivityDate]'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_Users]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ApplicationId],'
				SET @SQL = @SQL + ' [UserId],'
				SET @SQL = @SQL + ' [UserName],'
				SET @SQL = @SQL + ' [LoweredUserName],'
				SET @SQL = @SQL + ' [MobileAlias],'
				SET @SQL = @SQL + ' [IsAnonymous],'
				SET @SQL = @SQL + ' [LastActivityDate]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_Users]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Users_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Users_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Users_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the aspnet_Users table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Users_Insert
(

	@ApplicationId uniqueidentifier   ,

	@UserId uniqueidentifier    OUTPUT,

	@UserName nvarchar (256)  ,

	@LoweredUserName nvarchar (256)  ,

	@MobileAlias nvarchar (16)  ,

	@IsAnonymous bit   ,

	@LastActivityDate datetime   
)
AS


				
				Declare @IdentityRowGuids table (UserId uniqueidentifier	)
				INSERT INTO [dbo].[aspnet_Users]
					(
					[ApplicationId]
					,[UserName]
					,[LoweredUserName]
					,[MobileAlias]
					,[IsAnonymous]
					,[LastActivityDate]
					)
						OUTPUT INSERTED.UserId INTO @IdentityRowGuids
					
				VALUES
					(
					@ApplicationId
					,@UserName
					,@LoweredUserName
					,@MobileAlias
					,@IsAnonymous
					,@LastActivityDate
					)
				
				SELECT @UserId=UserId	 from @IdentityRowGuids
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Users_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Users_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Users_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the aspnet_Users table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Users_Update
(

	@ApplicationId uniqueidentifier   ,

	@UserId uniqueidentifier   ,

	@UserName nvarchar (256)  ,

	@LoweredUserName nvarchar (256)  ,

	@MobileAlias nvarchar (16)  ,

	@IsAnonymous bit   ,

	@LastActivityDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[aspnet_Users]
				SET
					[ApplicationId] = @ApplicationId
					,[UserName] = @UserName
					,[LoweredUserName] = @LoweredUserName
					,[MobileAlias] = @MobileAlias
					,[IsAnonymous] = @IsAnonymous
					,[LastActivityDate] = @LastActivityDate
				WHERE
[UserId] = @UserId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Users_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Users_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Users_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the aspnet_Users table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Users_Delete
(

	@UserId uniqueidentifier   
)
AS


				DELETE FROM [dbo].[aspnet_Users] WITH (ROWLOCK) 
				WHERE
					[UserId] = @UserId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Users_GetByApplicationId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Users_GetByApplicationId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Users_GetByApplicationId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Users table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Users_GetByApplicationId
(

	@ApplicationId uniqueidentifier   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ApplicationId],
					[UserId],
					[UserName],
					[LoweredUserName],
					[MobileAlias],
					[IsAnonymous],
					[LastActivityDate]
				FROM
					[dbo].[aspnet_Users]
				WHERE
					[ApplicationId] = @ApplicationId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Users_GetByApplicationIdLoweredUserName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Users_GetByApplicationIdLoweredUserName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Users_GetByApplicationIdLoweredUserName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Users table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Users_GetByApplicationIdLoweredUserName
(

	@ApplicationId uniqueidentifier   ,

	@LoweredUserName nvarchar (256)  
)
AS


				SELECT
					[ApplicationId],
					[UserId],
					[UserName],
					[LoweredUserName],
					[MobileAlias],
					[IsAnonymous],
					[LastActivityDate]
				FROM
					[dbo].[aspnet_Users]
				WHERE
					[ApplicationId] = @ApplicationId
					AND [LoweredUserName] = @LoweredUserName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Users_GetByApplicationIdLastActivityDate procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Users_GetByApplicationIdLastActivityDate') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Users_GetByApplicationIdLastActivityDate
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Users table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Users_GetByApplicationIdLastActivityDate
(

	@ApplicationId uniqueidentifier   ,

	@LastActivityDate datetime   
)
AS


				SELECT
					[ApplicationId],
					[UserId],
					[UserName],
					[LoweredUserName],
					[MobileAlias],
					[IsAnonymous],
					[LastActivityDate]
				FROM
					[dbo].[aspnet_Users]
				WHERE
					[ApplicationId] = @ApplicationId
					AND [LastActivityDate] = @LastActivityDate
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Users_GetByUserId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Users_GetByUserId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Users_GetByUserId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Users table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Users_GetByUserId
(

	@UserId uniqueidentifier   
)
AS


				SELECT
					[ApplicationId],
					[UserId],
					[UserName],
					[LoweredUserName],
					[MobileAlias],
					[IsAnonymous],
					[LastActivityDate]
				FROM
					[dbo].[aspnet_Users]
				WHERE
					[UserId] = @UserId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Users_GetByRoleIdFromAspnetUsersInRoles procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Users_GetByRoleIdFromAspnetUsersInRoles') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Users_GetByRoleIdFromAspnetUsersInRoles
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Users_GetByRoleIdFromAspnetUsersInRoles
(

	@RoleId uniqueidentifier   
)
AS


SELECT dbo.[aspnet_Users].[ApplicationId]
       ,dbo.[aspnet_Users].[UserId]
       ,dbo.[aspnet_Users].[UserName]
       ,dbo.[aspnet_Users].[LoweredUserName]
       ,dbo.[aspnet_Users].[MobileAlias]
       ,dbo.[aspnet_Users].[IsAnonymous]
       ,dbo.[aspnet_Users].[LastActivityDate]
  FROM dbo.[aspnet_Users]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[aspnet_UsersInRoles] 
                WHERE dbo.[aspnet_UsersInRoles].[RoleId] = @RoleId
                  AND dbo.[aspnet_UsersInRoles].[UserId] = dbo.[aspnet_Users].[UserId]
                  )
				SELECT @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Users_GetByGroupIdFromResult procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Users_GetByGroupIdFromResult') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Users_GetByGroupIdFromResult
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Users_GetByGroupIdFromResult
(

	@GroupId int   
)
AS


SELECT dbo.[aspnet_Users].[ApplicationId]
       ,dbo.[aspnet_Users].[UserId]
       ,dbo.[aspnet_Users].[UserName]
       ,dbo.[aspnet_Users].[LoweredUserName]
       ,dbo.[aspnet_Users].[MobileAlias]
       ,dbo.[aspnet_Users].[IsAnonymous]
       ,dbo.[aspnet_Users].[LastActivityDate]
  FROM dbo.[aspnet_Users]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[Result] 
                WHERE dbo.[Result].[GroupId] = @GroupId
                  AND dbo.[Result].[UserId] = dbo.[aspnet_Users].[UserId]
                  )
				SELECT @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Users_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Users_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Users_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the aspnet_Users table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Users_Find
(

	@SearchUsingOR bit   = null ,

	@ApplicationId uniqueidentifier   = null ,

	@UserId uniqueidentifier   = null ,

	@UserName nvarchar (256)  = null ,

	@LoweredUserName nvarchar (256)  = null ,

	@MobileAlias nvarchar (16)  = null ,

	@IsAnonymous bit   = null ,

	@LastActivityDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ApplicationId]
	, [UserId]
	, [UserName]
	, [LoweredUserName]
	, [MobileAlias]
	, [IsAnonymous]
	, [LastActivityDate]
    FROM
	[dbo].[aspnet_Users]
    WHERE 
	 ([ApplicationId] = @ApplicationId OR @ApplicationId IS NULL)
	AND ([UserId] = @UserId OR @UserId IS NULL)
	AND ([UserName] = @UserName OR @UserName IS NULL)
	AND ([LoweredUserName] = @LoweredUserName OR @LoweredUserName IS NULL)
	AND ([MobileAlias] = @MobileAlias OR @MobileAlias IS NULL)
	AND ([IsAnonymous] = @IsAnonymous OR @IsAnonymous IS NULL)
	AND ([LastActivityDate] = @LastActivityDate OR @LastActivityDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ApplicationId]
	, [UserId]
	, [UserName]
	, [LoweredUserName]
	, [MobileAlias]
	, [IsAnonymous]
	, [LastActivityDate]
    FROM
	[dbo].[aspnet_Users]
    WHERE 
	 ([ApplicationId] = @ApplicationId AND @ApplicationId is not null)
	OR ([UserId] = @UserId AND @UserId is not null)
	OR ([UserName] = @UserName AND @UserName is not null)
	OR ([LoweredUserName] = @LoweredUserName AND @LoweredUserName is not null)
	OR ([MobileAlias] = @MobileAlias AND @MobileAlias is not null)
	OR ([IsAnonymous] = @IsAnonymous AND @IsAnonymous is not null)
	OR ([LastActivityDate] = @LastActivityDate AND @LastActivityDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_SchemaVersions_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_SchemaVersions_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_SchemaVersions_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the aspnet_SchemaVersions table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_SchemaVersions_Get_List

AS


				
				SELECT
					[Feature],
					[CompatibleSchemaVersion],
					[IsCurrentVersion]
				FROM
					[dbo].[aspnet_SchemaVersions]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_SchemaVersions_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_SchemaVersions_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_SchemaVersions_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the aspnet_SchemaVersions table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_SchemaVersions_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Feature]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Feature]'
				SET @SQL = @SQL + ', [CompatibleSchemaVersion]'
				SET @SQL = @SQL + ', [IsCurrentVersion]'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_SchemaVersions]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Feature],'
				SET @SQL = @SQL + ' [CompatibleSchemaVersion],'
				SET @SQL = @SQL + ' [IsCurrentVersion]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_SchemaVersions]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_SchemaVersions_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_SchemaVersions_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_SchemaVersions_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the aspnet_SchemaVersions table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_SchemaVersions_Insert
(

	@Feature nvarchar (128)  ,

	@CompatibleSchemaVersion nvarchar (128)  ,

	@IsCurrentVersion bit   
)
AS


				
				INSERT INTO [dbo].[aspnet_SchemaVersions]
					(
					[Feature]
					,[CompatibleSchemaVersion]
					,[IsCurrentVersion]
					)
				VALUES
					(
					@Feature
					,@CompatibleSchemaVersion
					,@IsCurrentVersion
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_SchemaVersions_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_SchemaVersions_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_SchemaVersions_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the aspnet_SchemaVersions table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_SchemaVersions_Update
(

	@Feature nvarchar (128)  ,

	@OriginalFeature nvarchar (128)  ,

	@CompatibleSchemaVersion nvarchar (128)  ,

	@OriginalCompatibleSchemaVersion nvarchar (128)  ,

	@IsCurrentVersion bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[aspnet_SchemaVersions]
				SET
					[Feature] = @Feature
					,[CompatibleSchemaVersion] = @CompatibleSchemaVersion
					,[IsCurrentVersion] = @IsCurrentVersion
				WHERE
[Feature] = @OriginalFeature 
AND [CompatibleSchemaVersion] = @OriginalCompatibleSchemaVersion 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_SchemaVersions_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_SchemaVersions_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_SchemaVersions_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the aspnet_SchemaVersions table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_SchemaVersions_Delete
(

	@Feature nvarchar (128)  ,

	@CompatibleSchemaVersion nvarchar (128)  
)
AS


				DELETE FROM [dbo].[aspnet_SchemaVersions] WITH (ROWLOCK) 
				WHERE
					[Feature] = @Feature
					AND [CompatibleSchemaVersion] = @CompatibleSchemaVersion
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_SchemaVersions_GetByFeatureCompatibleSchemaVersion procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_SchemaVersions_GetByFeatureCompatibleSchemaVersion') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_SchemaVersions_GetByFeatureCompatibleSchemaVersion
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_SchemaVersions table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_SchemaVersions_GetByFeatureCompatibleSchemaVersion
(

	@Feature nvarchar (128)  ,

	@CompatibleSchemaVersion nvarchar (128)  
)
AS


				SELECT
					[Feature],
					[CompatibleSchemaVersion],
					[IsCurrentVersion]
				FROM
					[dbo].[aspnet_SchemaVersions]
				WHERE
					[Feature] = @Feature
					AND [CompatibleSchemaVersion] = @CompatibleSchemaVersion
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_SchemaVersions_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_SchemaVersions_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_SchemaVersions_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the aspnet_SchemaVersions table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_SchemaVersions_Find
(

	@SearchUsingOR bit   = null ,

	@Feature nvarchar (128)  = null ,

	@CompatibleSchemaVersion nvarchar (128)  = null ,

	@IsCurrentVersion bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Feature]
	, [CompatibleSchemaVersion]
	, [IsCurrentVersion]
    FROM
	[dbo].[aspnet_SchemaVersions]
    WHERE 
	 ([Feature] = @Feature OR @Feature IS NULL)
	AND ([CompatibleSchemaVersion] = @CompatibleSchemaVersion OR @CompatibleSchemaVersion IS NULL)
	AND ([IsCurrentVersion] = @IsCurrentVersion OR @IsCurrentVersion IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Feature]
	, [CompatibleSchemaVersion]
	, [IsCurrentVersion]
    FROM
	[dbo].[aspnet_SchemaVersions]
    WHERE 
	 ([Feature] = @Feature AND @Feature is not null)
	OR ([CompatibleSchemaVersion] = @CompatibleSchemaVersion AND @CompatibleSchemaVersion is not null)
	OR ([IsCurrentVersion] = @IsCurrentVersion AND @IsCurrentVersion is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Applications_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Applications_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Applications_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the aspnet_Applications table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Applications_Get_List

AS


				
				SELECT
					[ApplicationName],
					[LoweredApplicationName],
					[ApplicationId],
					[Description]
				FROM
					[dbo].[aspnet_Applications]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Applications_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Applications_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Applications_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the aspnet_Applications table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Applications_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ApplicationName]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ApplicationName]'
				SET @SQL = @SQL + ', [LoweredApplicationName]'
				SET @SQL = @SQL + ', [ApplicationId]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_Applications]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ApplicationName],'
				SET @SQL = @SQL + ' [LoweredApplicationName],'
				SET @SQL = @SQL + ' [ApplicationId],'
				SET @SQL = @SQL + ' [Description]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_Applications]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Applications_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Applications_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Applications_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the aspnet_Applications table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Applications_Insert
(

	@ApplicationName nvarchar (256)  ,

	@LoweredApplicationName nvarchar (256)  ,

	@ApplicationId uniqueidentifier    OUTPUT,

	@Description nvarchar (256)  
)
AS


				
				Declare @IdentityRowGuids table (ApplicationId uniqueidentifier	)
				INSERT INTO [dbo].[aspnet_Applications]
					(
					[ApplicationName]
					,[LoweredApplicationName]
					,[Description]
					)
						OUTPUT INSERTED.ApplicationId INTO @IdentityRowGuids
					
				VALUES
					(
					@ApplicationName
					,@LoweredApplicationName
					,@Description
					)
				
				SELECT @ApplicationId=ApplicationId	 from @IdentityRowGuids
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Applications_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Applications_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Applications_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the aspnet_Applications table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Applications_Update
(

	@ApplicationName nvarchar (256)  ,

	@LoweredApplicationName nvarchar (256)  ,

	@ApplicationId uniqueidentifier   ,

	@Description nvarchar (256)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[aspnet_Applications]
				SET
					[ApplicationName] = @ApplicationName
					,[LoweredApplicationName] = @LoweredApplicationName
					,[Description] = @Description
				WHERE
[ApplicationId] = @ApplicationId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Applications_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Applications_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Applications_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the aspnet_Applications table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Applications_Delete
(

	@ApplicationId uniqueidentifier   
)
AS


				DELETE FROM [dbo].[aspnet_Applications] WITH (ROWLOCK) 
				WHERE
					[ApplicationId] = @ApplicationId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Applications_GetByLoweredApplicationName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Applications_GetByLoweredApplicationName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Applications_GetByLoweredApplicationName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Applications table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Applications_GetByLoweredApplicationName
(

	@LoweredApplicationName nvarchar (256)  
)
AS


				SELECT
					[ApplicationName],
					[LoweredApplicationName],
					[ApplicationId],
					[Description]
				FROM
					[dbo].[aspnet_Applications]
				WHERE
					[LoweredApplicationName] = @LoweredApplicationName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Applications_GetByApplicationId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Applications_GetByApplicationId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Applications_GetByApplicationId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Applications table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Applications_GetByApplicationId
(

	@ApplicationId uniqueidentifier   
)
AS


				SELECT
					[ApplicationName],
					[LoweredApplicationName],
					[ApplicationId],
					[Description]
				FROM
					[dbo].[aspnet_Applications]
				WHERE
					[ApplicationId] = @ApplicationId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Applications_GetByApplicationName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Applications_GetByApplicationName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Applications_GetByApplicationName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Applications table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Applications_GetByApplicationName
(

	@ApplicationName nvarchar (256)  
)
AS


				SELECT
					[ApplicationName],
					[LoweredApplicationName],
					[ApplicationId],
					[Description]
				FROM
					[dbo].[aspnet_Applications]
				WHERE
					[ApplicationName] = @ApplicationName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Applications_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Applications_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Applications_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the aspnet_Applications table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Applications_Find
(

	@SearchUsingOR bit   = null ,

	@ApplicationName nvarchar (256)  = null ,

	@LoweredApplicationName nvarchar (256)  = null ,

	@ApplicationId uniqueidentifier   = null ,

	@Description nvarchar (256)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ApplicationName]
	, [LoweredApplicationName]
	, [ApplicationId]
	, [Description]
    FROM
	[dbo].[aspnet_Applications]
    WHERE 
	 ([ApplicationName] = @ApplicationName OR @ApplicationName IS NULL)
	AND ([LoweredApplicationName] = @LoweredApplicationName OR @LoweredApplicationName IS NULL)
	AND ([ApplicationId] = @ApplicationId OR @ApplicationId IS NULL)
	AND ([Description] = @Description OR @Description IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ApplicationName]
	, [LoweredApplicationName]
	, [ApplicationId]
	, [Description]
    FROM
	[dbo].[aspnet_Applications]
    WHERE 
	 ([ApplicationName] = @ApplicationName AND @ApplicationName is not null)
	OR ([LoweredApplicationName] = @LoweredApplicationName AND @LoweredApplicationName is not null)
	OR ([ApplicationId] = @ApplicationId AND @ApplicationId is not null)
	OR ([Description] = @Description AND @Description is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Roles_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Roles_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Roles_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the aspnet_Roles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Roles_Get_List

AS


				
				SELECT
					[ApplicationId],
					[RoleId],
					[RoleName],
					[LoweredRoleName],
					[Description]
				FROM
					[dbo].[aspnet_Roles]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Roles_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Roles_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Roles_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the aspnet_Roles table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Roles_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ApplicationId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ApplicationId]'
				SET @SQL = @SQL + ', [RoleId]'
				SET @SQL = @SQL + ', [RoleName]'
				SET @SQL = @SQL + ', [LoweredRoleName]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_Roles]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ApplicationId],'
				SET @SQL = @SQL + ' [RoleId],'
				SET @SQL = @SQL + ' [RoleName],'
				SET @SQL = @SQL + ' [LoweredRoleName],'
				SET @SQL = @SQL + ' [Description]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_Roles]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Roles_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Roles_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Roles_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the aspnet_Roles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Roles_Insert
(

	@ApplicationId uniqueidentifier   ,

	@RoleId uniqueidentifier    OUTPUT,

	@RoleName nvarchar (256)  ,

	@LoweredRoleName nvarchar (256)  ,

	@Description nvarchar (256)  
)
AS


				
				Declare @IdentityRowGuids table (RoleId uniqueidentifier	)
				INSERT INTO [dbo].[aspnet_Roles]
					(
					[ApplicationId]
					,[RoleName]
					,[LoweredRoleName]
					,[Description]
					)
						OUTPUT INSERTED.RoleId INTO @IdentityRowGuids
					
				VALUES
					(
					@ApplicationId
					,@RoleName
					,@LoweredRoleName
					,@Description
					)
				
				SELECT @RoleId=RoleId	 from @IdentityRowGuids
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Roles_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Roles_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Roles_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the aspnet_Roles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Roles_Update
(

	@ApplicationId uniqueidentifier   ,

	@RoleId uniqueidentifier   ,

	@RoleName nvarchar (256)  ,

	@LoweredRoleName nvarchar (256)  ,

	@Description nvarchar (256)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[aspnet_Roles]
				SET
					[ApplicationId] = @ApplicationId
					,[RoleName] = @RoleName
					,[LoweredRoleName] = @LoweredRoleName
					,[Description] = @Description
				WHERE
[RoleId] = @RoleId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Roles_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Roles_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Roles_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the aspnet_Roles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Roles_Delete
(

	@RoleId uniqueidentifier   
)
AS


				DELETE FROM [dbo].[aspnet_Roles] WITH (ROWLOCK) 
				WHERE
					[RoleId] = @RoleId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Roles_GetByApplicationId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Roles_GetByApplicationId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Roles_GetByApplicationId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Roles table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Roles_GetByApplicationId
(

	@ApplicationId uniqueidentifier   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ApplicationId],
					[RoleId],
					[RoleName],
					[LoweredRoleName],
					[Description]
				FROM
					[dbo].[aspnet_Roles]
				WHERE
					[ApplicationId] = @ApplicationId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Roles_GetByApplicationIdLoweredRoleName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Roles_GetByApplicationIdLoweredRoleName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Roles_GetByApplicationIdLoweredRoleName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Roles table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Roles_GetByApplicationIdLoweredRoleName
(

	@ApplicationId uniqueidentifier   ,

	@LoweredRoleName nvarchar (256)  
)
AS


				SELECT
					[ApplicationId],
					[RoleId],
					[RoleName],
					[LoweredRoleName],
					[Description]
				FROM
					[dbo].[aspnet_Roles]
				WHERE
					[ApplicationId] = @ApplicationId
					AND [LoweredRoleName] = @LoweredRoleName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Roles_GetByRoleId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Roles_GetByRoleId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Roles_GetByRoleId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Roles table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Roles_GetByRoleId
(

	@RoleId uniqueidentifier   
)
AS


				SELECT
					[ApplicationId],
					[RoleId],
					[RoleName],
					[LoweredRoleName],
					[Description]
				FROM
					[dbo].[aspnet_Roles]
				WHERE
					[RoleId] = @RoleId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Roles_GetByUserIdFromAspnetUsersInRoles procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Roles_GetByUserIdFromAspnetUsersInRoles') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Roles_GetByUserIdFromAspnetUsersInRoles
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Roles_GetByUserIdFromAspnetUsersInRoles
(

	@UserId uniqueidentifier   
)
AS


SELECT dbo.[aspnet_Roles].[ApplicationId]
       ,dbo.[aspnet_Roles].[RoleId]
       ,dbo.[aspnet_Roles].[RoleName]
       ,dbo.[aspnet_Roles].[LoweredRoleName]
       ,dbo.[aspnet_Roles].[Description]
  FROM dbo.[aspnet_Roles]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[aspnet_UsersInRoles] 
                WHERE dbo.[aspnet_UsersInRoles].[UserId] = @UserId
                  AND dbo.[aspnet_UsersInRoles].[RoleId] = dbo.[aspnet_Roles].[RoleId]
                  )
				SELECT @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Roles_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Roles_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Roles_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the aspnet_Roles table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Roles_Find
(

	@SearchUsingOR bit   = null ,

	@ApplicationId uniqueidentifier   = null ,

	@RoleId uniqueidentifier   = null ,

	@RoleName nvarchar (256)  = null ,

	@LoweredRoleName nvarchar (256)  = null ,

	@Description nvarchar (256)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ApplicationId]
	, [RoleId]
	, [RoleName]
	, [LoweredRoleName]
	, [Description]
    FROM
	[dbo].[aspnet_Roles]
    WHERE 
	 ([ApplicationId] = @ApplicationId OR @ApplicationId IS NULL)
	AND ([RoleId] = @RoleId OR @RoleId IS NULL)
	AND ([RoleName] = @RoleName OR @RoleName IS NULL)
	AND ([LoweredRoleName] = @LoweredRoleName OR @LoweredRoleName IS NULL)
	AND ([Description] = @Description OR @Description IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ApplicationId]
	, [RoleId]
	, [RoleName]
	, [LoweredRoleName]
	, [Description]
    FROM
	[dbo].[aspnet_Roles]
    WHERE 
	 ([ApplicationId] = @ApplicationId AND @ApplicationId is not null)
	OR ([RoleId] = @RoleId AND @RoleId is not null)
	OR ([RoleName] = @RoleName AND @RoleName is not null)
	OR ([LoweredRoleName] = @LoweredRoleName AND @LoweredRoleName is not null)
	OR ([Description] = @Description AND @Description is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Membership_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Membership_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Membership_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the aspnet_Membership table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Membership_Get_List

AS


				
				SELECT
					[ApplicationId],
					[UserId],
					[Password],
					[PasswordFormat],
					[PasswordSalt],
					[MobilePIN],
					[Email],
					[LoweredEmail],
					[PasswordQuestion],
					[PasswordAnswer],
					[IsApproved],
					[IsLockedOut],
					[CreateDate],
					[LastLoginDate],
					[LastPasswordChangedDate],
					[LastLockoutDate],
					[FailedPasswordAttemptCount],
					[FailedPasswordAttemptWindowStart],
					[FailedPasswordAnswerAttemptCount],
					[FailedPasswordAnswerAttemptWindowStart],
					[Comment]
				FROM
					[dbo].[aspnet_Membership]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Membership_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Membership_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Membership_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the aspnet_Membership table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Membership_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ApplicationId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ApplicationId]'
				SET @SQL = @SQL + ', [UserId]'
				SET @SQL = @SQL + ', [Password]'
				SET @SQL = @SQL + ', [PasswordFormat]'
				SET @SQL = @SQL + ', [PasswordSalt]'
				SET @SQL = @SQL + ', [MobilePIN]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ', [LoweredEmail]'
				SET @SQL = @SQL + ', [PasswordQuestion]'
				SET @SQL = @SQL + ', [PasswordAnswer]'
				SET @SQL = @SQL + ', [IsApproved]'
				SET @SQL = @SQL + ', [IsLockedOut]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [LastLoginDate]'
				SET @SQL = @SQL + ', [LastPasswordChangedDate]'
				SET @SQL = @SQL + ', [LastLockoutDate]'
				SET @SQL = @SQL + ', [FailedPasswordAttemptCount]'
				SET @SQL = @SQL + ', [FailedPasswordAttemptWindowStart]'
				SET @SQL = @SQL + ', [FailedPasswordAnswerAttemptCount]'
				SET @SQL = @SQL + ', [FailedPasswordAnswerAttemptWindowStart]'
				SET @SQL = @SQL + ', [Comment]'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_Membership]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ApplicationId],'
				SET @SQL = @SQL + ' [UserId],'
				SET @SQL = @SQL + ' [Password],'
				SET @SQL = @SQL + ' [PasswordFormat],'
				SET @SQL = @SQL + ' [PasswordSalt],'
				SET @SQL = @SQL + ' [MobilePIN],'
				SET @SQL = @SQL + ' [Email],'
				SET @SQL = @SQL + ' [LoweredEmail],'
				SET @SQL = @SQL + ' [PasswordQuestion],'
				SET @SQL = @SQL + ' [PasswordAnswer],'
				SET @SQL = @SQL + ' [IsApproved],'
				SET @SQL = @SQL + ' [IsLockedOut],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [LastLoginDate],'
				SET @SQL = @SQL + ' [LastPasswordChangedDate],'
				SET @SQL = @SQL + ' [LastLockoutDate],'
				SET @SQL = @SQL + ' [FailedPasswordAttemptCount],'
				SET @SQL = @SQL + ' [FailedPasswordAttemptWindowStart],'
				SET @SQL = @SQL + ' [FailedPasswordAnswerAttemptCount],'
				SET @SQL = @SQL + ' [FailedPasswordAnswerAttemptWindowStart],'
				SET @SQL = @SQL + ' [Comment]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_Membership]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Membership_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Membership_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Membership_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the aspnet_Membership table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Membership_Insert
(

	@ApplicationId uniqueidentifier   ,

	@UserId uniqueidentifier   ,

	@Password nvarchar (128)  ,

	@PasswordFormat int   ,

	@PasswordSalt nvarchar (128)  ,

	@MobilePin nvarchar (16)  ,

	@Email nvarchar (256)  ,

	@LoweredEmail nvarchar (256)  ,

	@PasswordQuestion nvarchar (256)  ,

	@PasswordAnswer nvarchar (128)  ,

	@IsApproved bit   ,

	@IsLockedOut bit   ,

	@CreateDate datetime   ,

	@LastLoginDate datetime   ,

	@LastPasswordChangedDate datetime   ,

	@LastLockoutDate datetime   ,

	@FailedPasswordAttemptCount int   ,

	@FailedPasswordAttemptWindowStart datetime   ,

	@FailedPasswordAnswerAttemptCount int   ,

	@FailedPasswordAnswerAttemptWindowStart datetime   ,

	@Comment ntext   
)
AS


				
				INSERT INTO [dbo].[aspnet_Membership]
					(
					[ApplicationId]
					,[UserId]
					,[Password]
					,[PasswordFormat]
					,[PasswordSalt]
					,[MobilePIN]
					,[Email]
					,[LoweredEmail]
					,[PasswordQuestion]
					,[PasswordAnswer]
					,[IsApproved]
					,[IsLockedOut]
					,[CreateDate]
					,[LastLoginDate]
					,[LastPasswordChangedDate]
					,[LastLockoutDate]
					,[FailedPasswordAttemptCount]
					,[FailedPasswordAttemptWindowStart]
					,[FailedPasswordAnswerAttemptCount]
					,[FailedPasswordAnswerAttemptWindowStart]
					,[Comment]
					)
				VALUES
					(
					@ApplicationId
					,@UserId
					,@Password
					,@PasswordFormat
					,@PasswordSalt
					,@MobilePin
					,@Email
					,@LoweredEmail
					,@PasswordQuestion
					,@PasswordAnswer
					,@IsApproved
					,@IsLockedOut
					,@CreateDate
					,@LastLoginDate
					,@LastPasswordChangedDate
					,@LastLockoutDate
					,@FailedPasswordAttemptCount
					,@FailedPasswordAttemptWindowStart
					,@FailedPasswordAnswerAttemptCount
					,@FailedPasswordAnswerAttemptWindowStart
					,@Comment
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Membership_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Membership_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Membership_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the aspnet_Membership table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Membership_Update
(

	@ApplicationId uniqueidentifier   ,

	@UserId uniqueidentifier   ,

	@OriginalUserId uniqueidentifier   ,

	@Password nvarchar (128)  ,

	@PasswordFormat int   ,

	@PasswordSalt nvarchar (128)  ,

	@MobilePin nvarchar (16)  ,

	@Email nvarchar (256)  ,

	@LoweredEmail nvarchar (256)  ,

	@PasswordQuestion nvarchar (256)  ,

	@PasswordAnswer nvarchar (128)  ,

	@IsApproved bit   ,

	@IsLockedOut bit   ,

	@CreateDate datetime   ,

	@LastLoginDate datetime   ,

	@LastPasswordChangedDate datetime   ,

	@LastLockoutDate datetime   ,

	@FailedPasswordAttemptCount int   ,

	@FailedPasswordAttemptWindowStart datetime   ,

	@FailedPasswordAnswerAttemptCount int   ,

	@FailedPasswordAnswerAttemptWindowStart datetime   ,

	@Comment ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[aspnet_Membership]
				SET
					[ApplicationId] = @ApplicationId
					,[UserId] = @UserId
					,[Password] = @Password
					,[PasswordFormat] = @PasswordFormat
					,[PasswordSalt] = @PasswordSalt
					,[MobilePIN] = @MobilePin
					,[Email] = @Email
					,[LoweredEmail] = @LoweredEmail
					,[PasswordQuestion] = @PasswordQuestion
					,[PasswordAnswer] = @PasswordAnswer
					,[IsApproved] = @IsApproved
					,[IsLockedOut] = @IsLockedOut
					,[CreateDate] = @CreateDate
					,[LastLoginDate] = @LastLoginDate
					,[LastPasswordChangedDate] = @LastPasswordChangedDate
					,[LastLockoutDate] = @LastLockoutDate
					,[FailedPasswordAttemptCount] = @FailedPasswordAttemptCount
					,[FailedPasswordAttemptWindowStart] = @FailedPasswordAttemptWindowStart
					,[FailedPasswordAnswerAttemptCount] = @FailedPasswordAnswerAttemptCount
					,[FailedPasswordAnswerAttemptWindowStart] = @FailedPasswordAnswerAttemptWindowStart
					,[Comment] = @Comment
				WHERE
[UserId] = @OriginalUserId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Membership_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Membership_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Membership_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the aspnet_Membership table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Membership_Delete
(

	@UserId uniqueidentifier   
)
AS


				DELETE FROM [dbo].[aspnet_Membership] WITH (ROWLOCK) 
				WHERE
					[UserId] = @UserId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Membership_GetByApplicationId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Membership_GetByApplicationId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Membership_GetByApplicationId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Membership table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Membership_GetByApplicationId
(

	@ApplicationId uniqueidentifier   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ApplicationId],
					[UserId],
					[Password],
					[PasswordFormat],
					[PasswordSalt],
					[MobilePIN],
					[Email],
					[LoweredEmail],
					[PasswordQuestion],
					[PasswordAnswer],
					[IsApproved],
					[IsLockedOut],
					[CreateDate],
					[LastLoginDate],
					[LastPasswordChangedDate],
					[LastLockoutDate],
					[FailedPasswordAttemptCount],
					[FailedPasswordAttemptWindowStart],
					[FailedPasswordAnswerAttemptCount],
					[FailedPasswordAnswerAttemptWindowStart],
					[Comment]
				FROM
					[dbo].[aspnet_Membership]
				WHERE
					[ApplicationId] = @ApplicationId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Membership_GetByApplicationIdLoweredEmail procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Membership_GetByApplicationIdLoweredEmail') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Membership_GetByApplicationIdLoweredEmail
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Membership table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Membership_GetByApplicationIdLoweredEmail
(

	@ApplicationId uniqueidentifier   ,

	@LoweredEmail nvarchar (256)  
)
AS


				SELECT
					[ApplicationId],
					[UserId],
					[Password],
					[PasswordFormat],
					[PasswordSalt],
					[MobilePIN],
					[Email],
					[LoweredEmail],
					[PasswordQuestion],
					[PasswordAnswer],
					[IsApproved],
					[IsLockedOut],
					[CreateDate],
					[LastLoginDate],
					[LastPasswordChangedDate],
					[LastLockoutDate],
					[FailedPasswordAttemptCount],
					[FailedPasswordAttemptWindowStart],
					[FailedPasswordAnswerAttemptCount],
					[FailedPasswordAnswerAttemptWindowStart],
					[Comment]
				FROM
					[dbo].[aspnet_Membership]
				WHERE
					[ApplicationId] = @ApplicationId
					AND [LoweredEmail] = @LoweredEmail
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Membership_GetByUserId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Membership_GetByUserId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Membership_GetByUserId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Membership table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Membership_GetByUserId
(

	@UserId uniqueidentifier   
)
AS


				SELECT
					[ApplicationId],
					[UserId],
					[Password],
					[PasswordFormat],
					[PasswordSalt],
					[MobilePIN],
					[Email],
					[LoweredEmail],
					[PasswordQuestion],
					[PasswordAnswer],
					[IsApproved],
					[IsLockedOut],
					[CreateDate],
					[LastLoginDate],
					[LastPasswordChangedDate],
					[LastLockoutDate],
					[FailedPasswordAttemptCount],
					[FailedPasswordAttemptWindowStart],
					[FailedPasswordAnswerAttemptCount],
					[FailedPasswordAnswerAttemptWindowStart],
					[Comment]
				FROM
					[dbo].[aspnet_Membership]
				WHERE
					[UserId] = @UserId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Membership_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Membership_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Membership_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the aspnet_Membership table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Membership_Find
(

	@SearchUsingOR bit   = null ,

	@ApplicationId uniqueidentifier   = null ,

	@UserId uniqueidentifier   = null ,

	@Password nvarchar (128)  = null ,

	@PasswordFormat int   = null ,

	@PasswordSalt nvarchar (128)  = null ,

	@MobilePin nvarchar (16)  = null ,

	@Email nvarchar (256)  = null ,

	@LoweredEmail nvarchar (256)  = null ,

	@PasswordQuestion nvarchar (256)  = null ,

	@PasswordAnswer nvarchar (128)  = null ,

	@IsApproved bit   = null ,

	@IsLockedOut bit   = null ,

	@CreateDate datetime   = null ,

	@LastLoginDate datetime   = null ,

	@LastPasswordChangedDate datetime   = null ,

	@LastLockoutDate datetime   = null ,

	@FailedPasswordAttemptCount int   = null ,

	@FailedPasswordAttemptWindowStart datetime   = null ,

	@FailedPasswordAnswerAttemptCount int   = null ,

	@FailedPasswordAnswerAttemptWindowStart datetime   = null ,

	@Comment ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ApplicationId]
	, [UserId]
	, [Password]
	, [PasswordFormat]
	, [PasswordSalt]
	, [MobilePIN]
	, [Email]
	, [LoweredEmail]
	, [PasswordQuestion]
	, [PasswordAnswer]
	, [IsApproved]
	, [IsLockedOut]
	, [CreateDate]
	, [LastLoginDate]
	, [LastPasswordChangedDate]
	, [LastLockoutDate]
	, [FailedPasswordAttemptCount]
	, [FailedPasswordAttemptWindowStart]
	, [FailedPasswordAnswerAttemptCount]
	, [FailedPasswordAnswerAttemptWindowStart]
	, [Comment]
    FROM
	[dbo].[aspnet_Membership]
    WHERE 
	 ([ApplicationId] = @ApplicationId OR @ApplicationId IS NULL)
	AND ([UserId] = @UserId OR @UserId IS NULL)
	AND ([Password] = @Password OR @Password IS NULL)
	AND ([PasswordFormat] = @PasswordFormat OR @PasswordFormat IS NULL)
	AND ([PasswordSalt] = @PasswordSalt OR @PasswordSalt IS NULL)
	AND ([MobilePIN] = @MobilePin OR @MobilePin IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([LoweredEmail] = @LoweredEmail OR @LoweredEmail IS NULL)
	AND ([PasswordQuestion] = @PasswordQuestion OR @PasswordQuestion IS NULL)
	AND ([PasswordAnswer] = @PasswordAnswer OR @PasswordAnswer IS NULL)
	AND ([IsApproved] = @IsApproved OR @IsApproved IS NULL)
	AND ([IsLockedOut] = @IsLockedOut OR @IsLockedOut IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([LastLoginDate] = @LastLoginDate OR @LastLoginDate IS NULL)
	AND ([LastPasswordChangedDate] = @LastPasswordChangedDate OR @LastPasswordChangedDate IS NULL)
	AND ([LastLockoutDate] = @LastLockoutDate OR @LastLockoutDate IS NULL)
	AND ([FailedPasswordAttemptCount] = @FailedPasswordAttemptCount OR @FailedPasswordAttemptCount IS NULL)
	AND ([FailedPasswordAttemptWindowStart] = @FailedPasswordAttemptWindowStart OR @FailedPasswordAttemptWindowStart IS NULL)
	AND ([FailedPasswordAnswerAttemptCount] = @FailedPasswordAnswerAttemptCount OR @FailedPasswordAnswerAttemptCount IS NULL)
	AND ([FailedPasswordAnswerAttemptWindowStart] = @FailedPasswordAnswerAttemptWindowStart OR @FailedPasswordAnswerAttemptWindowStart IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ApplicationId]
	, [UserId]
	, [Password]
	, [PasswordFormat]
	, [PasswordSalt]
	, [MobilePIN]
	, [Email]
	, [LoweredEmail]
	, [PasswordQuestion]
	, [PasswordAnswer]
	, [IsApproved]
	, [IsLockedOut]
	, [CreateDate]
	, [LastLoginDate]
	, [LastPasswordChangedDate]
	, [LastLockoutDate]
	, [FailedPasswordAttemptCount]
	, [FailedPasswordAttemptWindowStart]
	, [FailedPasswordAnswerAttemptCount]
	, [FailedPasswordAnswerAttemptWindowStart]
	, [Comment]
    FROM
	[dbo].[aspnet_Membership]
    WHERE 
	 ([ApplicationId] = @ApplicationId AND @ApplicationId is not null)
	OR ([UserId] = @UserId AND @UserId is not null)
	OR ([Password] = @Password AND @Password is not null)
	OR ([PasswordFormat] = @PasswordFormat AND @PasswordFormat is not null)
	OR ([PasswordSalt] = @PasswordSalt AND @PasswordSalt is not null)
	OR ([MobilePIN] = @MobilePin AND @MobilePin is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([LoweredEmail] = @LoweredEmail AND @LoweredEmail is not null)
	OR ([PasswordQuestion] = @PasswordQuestion AND @PasswordQuestion is not null)
	OR ([PasswordAnswer] = @PasswordAnswer AND @PasswordAnswer is not null)
	OR ([IsApproved] = @IsApproved AND @IsApproved is not null)
	OR ([IsLockedOut] = @IsLockedOut AND @IsLockedOut is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([LastLoginDate] = @LastLoginDate AND @LastLoginDate is not null)
	OR ([LastPasswordChangedDate] = @LastPasswordChangedDate AND @LastPasswordChangedDate is not null)
	OR ([LastLockoutDate] = @LastLockoutDate AND @LastLockoutDate is not null)
	OR ([FailedPasswordAttemptCount] = @FailedPasswordAttemptCount AND @FailedPasswordAttemptCount is not null)
	OR ([FailedPasswordAttemptWindowStart] = @FailedPasswordAttemptWindowStart AND @FailedPasswordAttemptWindowStart is not null)
	OR ([FailedPasswordAnswerAttemptCount] = @FailedPasswordAnswerAttemptCount AND @FailedPasswordAnswerAttemptCount is not null)
	OR ([FailedPasswordAnswerAttemptWindowStart] = @FailedPasswordAnswerAttemptWindowStart AND @FailedPasswordAnswerAttemptWindowStart is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Paths_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Paths_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Paths_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the aspnet_Paths table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Paths_Get_List

AS


				
				SELECT
					[ApplicationId],
					[PathId],
					[Path],
					[LoweredPath]
				FROM
					[dbo].[aspnet_Paths]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Paths_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Paths_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Paths_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the aspnet_Paths table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Paths_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ApplicationId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ApplicationId]'
				SET @SQL = @SQL + ', [PathId]'
				SET @SQL = @SQL + ', [Path]'
				SET @SQL = @SQL + ', [LoweredPath]'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_Paths]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ApplicationId],'
				SET @SQL = @SQL + ' [PathId],'
				SET @SQL = @SQL + ' [Path],'
				SET @SQL = @SQL + ' [LoweredPath]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_Paths]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Paths_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Paths_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Paths_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the aspnet_Paths table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Paths_Insert
(

	@ApplicationId uniqueidentifier   ,

	@PathId uniqueidentifier    OUTPUT,

	@Path nvarchar (256)  ,

	@LoweredPath nvarchar (256)  
)
AS


				
				Declare @IdentityRowGuids table (PathId uniqueidentifier	)
				INSERT INTO [dbo].[aspnet_Paths]
					(
					[ApplicationId]
					,[Path]
					,[LoweredPath]
					)
						OUTPUT INSERTED.PathId INTO @IdentityRowGuids
					
				VALUES
					(
					@ApplicationId
					,@Path
					,@LoweredPath
					)
				
				SELECT @PathId=PathId	 from @IdentityRowGuids
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Paths_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Paths_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Paths_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the aspnet_Paths table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Paths_Update
(

	@ApplicationId uniqueidentifier   ,

	@PathId uniqueidentifier   ,

	@Path nvarchar (256)  ,

	@LoweredPath nvarchar (256)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[aspnet_Paths]
				SET
					[ApplicationId] = @ApplicationId
					,[Path] = @Path
					,[LoweredPath] = @LoweredPath
				WHERE
[PathId] = @PathId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Paths_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Paths_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Paths_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the aspnet_Paths table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Paths_Delete
(

	@PathId uniqueidentifier   
)
AS


				DELETE FROM [dbo].[aspnet_Paths] WITH (ROWLOCK) 
				WHERE
					[PathId] = @PathId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Paths_GetByApplicationId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Paths_GetByApplicationId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Paths_GetByApplicationId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Paths table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Paths_GetByApplicationId
(

	@ApplicationId uniqueidentifier   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ApplicationId],
					[PathId],
					[Path],
					[LoweredPath]
				FROM
					[dbo].[aspnet_Paths]
				WHERE
					[ApplicationId] = @ApplicationId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Paths_GetByApplicationIdLoweredPath procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Paths_GetByApplicationIdLoweredPath') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Paths_GetByApplicationIdLoweredPath
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Paths table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Paths_GetByApplicationIdLoweredPath
(

	@ApplicationId uniqueidentifier   ,

	@LoweredPath nvarchar (256)  
)
AS


				SELECT
					[ApplicationId],
					[PathId],
					[Path],
					[LoweredPath]
				FROM
					[dbo].[aspnet_Paths]
				WHERE
					[ApplicationId] = @ApplicationId
					AND [LoweredPath] = @LoweredPath
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Paths_GetByPathId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Paths_GetByPathId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Paths_GetByPathId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Paths table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Paths_GetByPathId
(

	@PathId uniqueidentifier   
)
AS


				SELECT
					[ApplicationId],
					[PathId],
					[Path],
					[LoweredPath]
				FROM
					[dbo].[aspnet_Paths]
				WHERE
					[PathId] = @PathId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Paths_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Paths_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Paths_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the aspnet_Paths table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Paths_Find
(

	@SearchUsingOR bit   = null ,

	@ApplicationId uniqueidentifier   = null ,

	@PathId uniqueidentifier   = null ,

	@Path nvarchar (256)  = null ,

	@LoweredPath nvarchar (256)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ApplicationId]
	, [PathId]
	, [Path]
	, [LoweredPath]
    FROM
	[dbo].[aspnet_Paths]
    WHERE 
	 ([ApplicationId] = @ApplicationId OR @ApplicationId IS NULL)
	AND ([PathId] = @PathId OR @PathId IS NULL)
	AND ([Path] = @Path OR @Path IS NULL)
	AND ([LoweredPath] = @LoweredPath OR @LoweredPath IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ApplicationId]
	, [PathId]
	, [Path]
	, [LoweredPath]
    FROM
	[dbo].[aspnet_Paths]
    WHERE 
	 ([ApplicationId] = @ApplicationId AND @ApplicationId is not null)
	OR ([PathId] = @PathId AND @PathId is not null)
	OR ([Path] = @Path AND @Path is not null)
	OR ([LoweredPath] = @LoweredPath AND @LoweredPath is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Profile_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Profile_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Profile_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the aspnet_Profile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Profile_Get_List

AS


				
				SELECT
					[UserId],
					[PropertyNames],
					[PropertyValuesString],
					[PropertyValuesBinary],
					[LastUpdatedDate]
				FROM
					[dbo].[aspnet_Profile]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Profile_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Profile_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Profile_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the aspnet_Profile table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Profile_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[UserId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [UserId]'
				SET @SQL = @SQL + ', [PropertyNames]'
				SET @SQL = @SQL + ', [PropertyValuesString]'
				SET @SQL = @SQL + ', [PropertyValuesBinary]'
				SET @SQL = @SQL + ', [LastUpdatedDate]'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_Profile]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [UserId],'
				SET @SQL = @SQL + ' [PropertyNames],'
				SET @SQL = @SQL + ' [PropertyValuesString],'
				SET @SQL = @SQL + ' [PropertyValuesBinary],'
				SET @SQL = @SQL + ' [LastUpdatedDate]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_Profile]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Profile_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Profile_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Profile_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the aspnet_Profile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Profile_Insert
(

	@UserId uniqueidentifier   ,

	@PropertyNames ntext   ,

	@PropertyValuesString ntext   ,

	@PropertyValuesBinary image   ,

	@LastUpdatedDate datetime   
)
AS


				
				INSERT INTO [dbo].[aspnet_Profile]
					(
					[UserId]
					,[PropertyNames]
					,[PropertyValuesString]
					,[PropertyValuesBinary]
					,[LastUpdatedDate]
					)
				VALUES
					(
					@UserId
					,@PropertyNames
					,@PropertyValuesString
					,@PropertyValuesBinary
					,@LastUpdatedDate
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Profile_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Profile_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Profile_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the aspnet_Profile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Profile_Update
(

	@UserId uniqueidentifier   ,

	@OriginalUserId uniqueidentifier   ,

	@PropertyNames ntext   ,

	@PropertyValuesString ntext   ,

	@PropertyValuesBinary image   ,

	@LastUpdatedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[aspnet_Profile]
				SET
					[UserId] = @UserId
					,[PropertyNames] = @PropertyNames
					,[PropertyValuesString] = @PropertyValuesString
					,[PropertyValuesBinary] = @PropertyValuesBinary
					,[LastUpdatedDate] = @LastUpdatedDate
				WHERE
[UserId] = @OriginalUserId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Profile_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Profile_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Profile_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the aspnet_Profile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Profile_Delete
(

	@UserId uniqueidentifier   
)
AS


				DELETE FROM [dbo].[aspnet_Profile] WITH (ROWLOCK) 
				WHERE
					[UserId] = @UserId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Profile_GetByUserId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Profile_GetByUserId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Profile_GetByUserId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_Profile table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Profile_GetByUserId
(

	@UserId uniqueidentifier   
)
AS


				SELECT
					[UserId],
					[PropertyNames],
					[PropertyValuesString],
					[PropertyValuesBinary],
					[LastUpdatedDate]
				FROM
					[dbo].[aspnet_Profile]
				WHERE
					[UserId] = @UserId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_Profile_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_Profile_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_Profile_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the aspnet_Profile table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_Profile_Find
(

	@SearchUsingOR bit   = null ,

	@UserId uniqueidentifier   = null ,

	@PropertyNames ntext   = null ,

	@PropertyValuesString ntext   = null ,

	@PropertyValuesBinary image   = null ,

	@LastUpdatedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [UserId]
	, [PropertyNames]
	, [PropertyValuesString]
	, [PropertyValuesBinary]
	, [LastUpdatedDate]
    FROM
	[dbo].[aspnet_Profile]
    WHERE 
	 ([UserId] = @UserId OR @UserId IS NULL)
	AND ([LastUpdatedDate] = @LastUpdatedDate OR @LastUpdatedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [UserId]
	, [PropertyNames]
	, [PropertyValuesString]
	, [PropertyValuesBinary]
	, [LastUpdatedDate]
    FROM
	[dbo].[aspnet_Profile]
    WHERE 
	 ([UserId] = @UserId AND @UserId is not null)
	OR ([LastUpdatedDate] = @LastUpdatedDate AND @LastUpdatedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationAllUsers_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationAllUsers_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationAllUsers_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the aspnet_PersonalizationAllUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationAllUsers_Get_List

AS


				
				SELECT
					[PathId],
					[PageSettings],
					[LastUpdatedDate]
				FROM
					[dbo].[aspnet_PersonalizationAllUsers]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationAllUsers_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationAllUsers_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationAllUsers_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the aspnet_PersonalizationAllUsers table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationAllUsers_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[PathId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [PathId]'
				SET @SQL = @SQL + ', [PageSettings]'
				SET @SQL = @SQL + ', [LastUpdatedDate]'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_PersonalizationAllUsers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [PathId],'
				SET @SQL = @SQL + ' [PageSettings],'
				SET @SQL = @SQL + ' [LastUpdatedDate]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_PersonalizationAllUsers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationAllUsers_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationAllUsers_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationAllUsers_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the aspnet_PersonalizationAllUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationAllUsers_Insert
(

	@PathId uniqueidentifier   ,

	@PageSettings image   ,

	@LastUpdatedDate datetime   
)
AS


				
				INSERT INTO [dbo].[aspnet_PersonalizationAllUsers]
					(
					[PathId]
					,[PageSettings]
					,[LastUpdatedDate]
					)
				VALUES
					(
					@PathId
					,@PageSettings
					,@LastUpdatedDate
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationAllUsers_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationAllUsers_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationAllUsers_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the aspnet_PersonalizationAllUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationAllUsers_Update
(

	@PathId uniqueidentifier   ,

	@OriginalPathId uniqueidentifier   ,

	@PageSettings image   ,

	@LastUpdatedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[aspnet_PersonalizationAllUsers]
				SET
					[PathId] = @PathId
					,[PageSettings] = @PageSettings
					,[LastUpdatedDate] = @LastUpdatedDate
				WHERE
[PathId] = @OriginalPathId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationAllUsers_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationAllUsers_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationAllUsers_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the aspnet_PersonalizationAllUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationAllUsers_Delete
(

	@PathId uniqueidentifier   
)
AS


				DELETE FROM [dbo].[aspnet_PersonalizationAllUsers] WITH (ROWLOCK) 
				WHERE
					[PathId] = @PathId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationAllUsers_GetByPathId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationAllUsers_GetByPathId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationAllUsers_GetByPathId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_PersonalizationAllUsers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationAllUsers_GetByPathId
(

	@PathId uniqueidentifier   
)
AS


				SELECT
					[PathId],
					[PageSettings],
					[LastUpdatedDate]
				FROM
					[dbo].[aspnet_PersonalizationAllUsers]
				WHERE
					[PathId] = @PathId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationAllUsers_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationAllUsers_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationAllUsers_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the aspnet_PersonalizationAllUsers table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationAllUsers_Find
(

	@SearchUsingOR bit   = null ,

	@PathId uniqueidentifier   = null ,

	@PageSettings image   = null ,

	@LastUpdatedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [PathId]
	, [PageSettings]
	, [LastUpdatedDate]
    FROM
	[dbo].[aspnet_PersonalizationAllUsers]
    WHERE 
	 ([PathId] = @PathId OR @PathId IS NULL)
	AND ([LastUpdatedDate] = @LastUpdatedDate OR @LastUpdatedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [PathId]
	, [PageSettings]
	, [LastUpdatedDate]
    FROM
	[dbo].[aspnet_PersonalizationAllUsers]
    WHERE 
	 ([PathId] = @PathId AND @PathId is not null)
	OR ([LastUpdatedDate] = @LastUpdatedDate AND @LastUpdatedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.User_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.User_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.User_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the User table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.User_Get_List

AS


				
				SELECT
					[UserId],
					[CompanyName],
					[Phone],
					[Fax],
					[Email],
					[Address],
					[EmployeeNumber],
					[Director],
					[Country],
					[City],
					[District]
				FROM
					[dbo].[User]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.User_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.User_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.User_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the User table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.User_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[UserId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [UserId]'
				SET @SQL = @SQL + ', [CompanyName]'
				SET @SQL = @SQL + ', [Phone]'
				SET @SQL = @SQL + ', [Fax]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ', [Address]'
				SET @SQL = @SQL + ', [EmployeeNumber]'
				SET @SQL = @SQL + ', [Director]'
				SET @SQL = @SQL + ', [Country]'
				SET @SQL = @SQL + ', [City]'
				SET @SQL = @SQL + ', [District]'
				SET @SQL = @SQL + ' FROM [dbo].[User]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [UserId],'
				SET @SQL = @SQL + ' [CompanyName],'
				SET @SQL = @SQL + ' [Phone],'
				SET @SQL = @SQL + ' [Fax],'
				SET @SQL = @SQL + ' [Email],'
				SET @SQL = @SQL + ' [Address],'
				SET @SQL = @SQL + ' [EmployeeNumber],'
				SET @SQL = @SQL + ' [Director],'
				SET @SQL = @SQL + ' [Country],'
				SET @SQL = @SQL + ' [City],'
				SET @SQL = @SQL + ' [District]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[User]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.User_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.User_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.User_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the User table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.User_Insert
(

	@UserId uniqueidentifier   ,

	@CompanyName nvarchar (256)  ,

	@Phone nvarchar (32)  ,

	@Fax nvarchar (32)  ,

	@Email nvarchar (256)  ,

	@Address nvarchar (512)  ,

	@EmployeeNumber int   ,

	@Director nvarchar (512)  ,

	@Country nvarchar (512)  ,

	@City nvarchar (512)  ,

	@District nvarchar (512)  
)
AS


				
				INSERT INTO [dbo].[User]
					(
					[UserId]
					,[CompanyName]
					,[Phone]
					,[Fax]
					,[Email]
					,[Address]
					,[EmployeeNumber]
					,[Director]
					,[Country]
					,[City]
					,[District]
					)
				VALUES
					(
					@UserId
					,@CompanyName
					,@Phone
					,@Fax
					,@Email
					,@Address
					,@EmployeeNumber
					,@Director
					,@Country
					,@City
					,@District
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.User_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.User_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.User_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the User table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.User_Update
(

	@UserId uniqueidentifier   ,

	@OriginalUserId uniqueidentifier   ,

	@CompanyName nvarchar (256)  ,

	@Phone nvarchar (32)  ,

	@Fax nvarchar (32)  ,

	@Email nvarchar (256)  ,

	@Address nvarchar (512)  ,

	@EmployeeNumber int   ,

	@Director nvarchar (512)  ,

	@Country nvarchar (512)  ,

	@City nvarchar (512)  ,

	@District nvarchar (512)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[User]
				SET
					[UserId] = @UserId
					,[CompanyName] = @CompanyName
					,[Phone] = @Phone
					,[Fax] = @Fax
					,[Email] = @Email
					,[Address] = @Address
					,[EmployeeNumber] = @EmployeeNumber
					,[Director] = @Director
					,[Country] = @Country
					,[City] = @City
					,[District] = @District
				WHERE
[UserId] = @OriginalUserId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.User_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.User_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.User_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the User table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.User_Delete
(

	@UserId uniqueidentifier   
)
AS


				DELETE FROM [dbo].[User] WITH (ROWLOCK) 
				WHERE
					[UserId] = @UserId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.User_GetByUserId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.User_GetByUserId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.User_GetByUserId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the User table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.User_GetByUserId
(

	@UserId uniqueidentifier   
)
AS


				SELECT
					[UserId],
					[CompanyName],
					[Phone],
					[Fax],
					[Email],
					[Address],
					[EmployeeNumber],
					[Director],
					[Country],
					[City],
					[District]
				FROM
					[dbo].[User]
				WHERE
					[UserId] = @UserId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.User_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.User_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.User_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the User table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.User_Find
(

	@SearchUsingOR bit   = null ,

	@UserId uniqueidentifier   = null ,

	@CompanyName nvarchar (256)  = null ,

	@Phone nvarchar (32)  = null ,

	@Fax nvarchar (32)  = null ,

	@Email nvarchar (256)  = null ,

	@Address nvarchar (512)  = null ,

	@EmployeeNumber int   = null ,

	@Director nvarchar (512)  = null ,

	@Country nvarchar (512)  = null ,

	@City nvarchar (512)  = null ,

	@District nvarchar (512)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [UserId]
	, [CompanyName]
	, [Phone]
	, [Fax]
	, [Email]
	, [Address]
	, [EmployeeNumber]
	, [Director]
	, [Country]
	, [City]
	, [District]
    FROM
	[dbo].[User]
    WHERE 
	 ([UserId] = @UserId OR @UserId IS NULL)
	AND ([CompanyName] = @CompanyName OR @CompanyName IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
	AND ([Fax] = @Fax OR @Fax IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
	AND ([EmployeeNumber] = @EmployeeNumber OR @EmployeeNumber IS NULL)
	AND ([Director] = @Director OR @Director IS NULL)
	AND ([Country] = @Country OR @Country IS NULL)
	AND ([City] = @City OR @City IS NULL)
	AND ([District] = @District OR @District IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [UserId]
	, [CompanyName]
	, [Phone]
	, [Fax]
	, [Email]
	, [Address]
	, [EmployeeNumber]
	, [Director]
	, [Country]
	, [City]
	, [District]
    FROM
	[dbo].[User]
    WHERE 
	 ([UserId] = @UserId AND @UserId is not null)
	OR ([CompanyName] = @CompanyName AND @CompanyName is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([Fax] = @Fax AND @Fax is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Address] = @Address AND @Address is not null)
	OR ([EmployeeNumber] = @EmployeeNumber AND @EmployeeNumber is not null)
	OR ([Director] = @Director AND @Director is not null)
	OR ([Country] = @Country AND @Country is not null)
	OR ([City] = @City AND @City is not null)
	OR ([District] = @District AND @District is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationPerUser_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationPerUser_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationPerUser_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets all records from the aspnet_PersonalizationPerUser table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationPerUser_Get_List

AS


				
				SELECT
					[Id],
					[PathId],
					[UserId],
					[PageSettings],
					[LastUpdatedDate]
				FROM
					[dbo].[aspnet_PersonalizationPerUser]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationPerUser_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationPerUser_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationPerUser_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Gets records from the aspnet_PersonalizationPerUser table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationPerUser_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Id]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Id]'
				SET @SQL = @SQL + ', [PathId]'
				SET @SQL = @SQL + ', [UserId]'
				SET @SQL = @SQL + ', [PageSettings]'
				SET @SQL = @SQL + ', [LastUpdatedDate]'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_PersonalizationPerUser]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Id],'
				SET @SQL = @SQL + ' [PathId],'
				SET @SQL = @SQL + ' [UserId],'
				SET @SQL = @SQL + ' [PageSettings],'
				SET @SQL = @SQL + ' [LastUpdatedDate]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[aspnet_PersonalizationPerUser]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationPerUser_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationPerUser_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationPerUser_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Inserts a record into the aspnet_PersonalizationPerUser table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationPerUser_Insert
(

	@Id uniqueidentifier    OUTPUT,

	@PathId uniqueidentifier   ,

	@UserId uniqueidentifier   ,

	@PageSettings image   ,

	@LastUpdatedDate datetime   
)
AS


				
				Declare @IdentityRowGuids table (Id uniqueidentifier	)
				INSERT INTO [dbo].[aspnet_PersonalizationPerUser]
					(
					[PathId]
					,[UserId]
					,[PageSettings]
					,[LastUpdatedDate]
					)
						OUTPUT INSERTED.Id INTO @IdentityRowGuids
					
				VALUES
					(
					@PathId
					,@UserId
					,@PageSettings
					,@LastUpdatedDate
					)
				
				SELECT @Id=Id	 from @IdentityRowGuids
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationPerUser_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationPerUser_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationPerUser_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Updates a record in the aspnet_PersonalizationPerUser table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationPerUser_Update
(

	@Id uniqueidentifier   ,

	@PathId uniqueidentifier   ,

	@UserId uniqueidentifier   ,

	@PageSettings image   ,

	@LastUpdatedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[aspnet_PersonalizationPerUser]
				SET
					[PathId] = @PathId
					,[UserId] = @UserId
					,[PageSettings] = @PageSettings
					,[LastUpdatedDate] = @LastUpdatedDate
				WHERE
[Id] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationPerUser_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationPerUser_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationPerUser_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Deletes a record in the aspnet_PersonalizationPerUser table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationPerUser_Delete
(

	@Id uniqueidentifier   
)
AS


				DELETE FROM [dbo].[aspnet_PersonalizationPerUser] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationPerUser_GetByPathId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationPerUser_GetByPathId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationPerUser_GetByPathId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_PersonalizationPerUser table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationPerUser_GetByPathId
(

	@PathId uniqueidentifier   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[PathId],
					[UserId],
					[PageSettings],
					[LastUpdatedDate]
				FROM
					[dbo].[aspnet_PersonalizationPerUser]
				WHERE
					[PathId] = @PathId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationPerUser_GetByUserId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationPerUser_GetByUserId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationPerUser_GetByUserId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_PersonalizationPerUser table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationPerUser_GetByUserId
(

	@UserId uniqueidentifier   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[PathId],
					[UserId],
					[PageSettings],
					[LastUpdatedDate]
				FROM
					[dbo].[aspnet_PersonalizationPerUser]
				WHERE
					[UserId] = @UserId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationPerUser_GetByPathIdUserId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationPerUser_GetByPathIdUserId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationPerUser_GetByPathIdUserId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_PersonalizationPerUser table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationPerUser_GetByPathIdUserId
(

	@PathId uniqueidentifier   ,

	@UserId uniqueidentifier   
)
AS


				SELECT
					[Id],
					[PathId],
					[UserId],
					[PageSettings],
					[LastUpdatedDate]
				FROM
					[dbo].[aspnet_PersonalizationPerUser]
				WHERE
					[PathId] = @PathId
					AND [UserId] = @UserId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationPerUser_GetByUserIdPathId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationPerUser_GetByUserIdPathId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationPerUser_GetByUserIdPathId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_PersonalizationPerUser table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationPerUser_GetByUserIdPathId
(

	@UserId uniqueidentifier   ,

	@PathId uniqueidentifier   
)
AS


				SELECT
					[Id],
					[PathId],
					[UserId],
					[PageSettings],
					[LastUpdatedDate]
				FROM
					[dbo].[aspnet_PersonalizationPerUser]
				WHERE
					[UserId] = @UserId
					AND [PathId] = @PathId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationPerUser_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationPerUser_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationPerUser_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Select records from the aspnet_PersonalizationPerUser table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationPerUser_GetById
(

	@Id uniqueidentifier   
)
AS


				SELECT
					[Id],
					[PathId],
					[UserId],
					[PageSettings],
					[LastUpdatedDate]
				FROM
					[dbo].[aspnet_PersonalizationPerUser]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.aspnet_PersonalizationPerUser_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.aspnet_PersonalizationPerUser_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.aspnet_PersonalizationPerUser_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NDMS ()
-- Purpose: Finds records in the aspnet_PersonalizationPerUser table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.aspnet_PersonalizationPerUser_Find
(

	@SearchUsingOR bit   = null ,

	@Id uniqueidentifier   = null ,

	@PathId uniqueidentifier   = null ,

	@UserId uniqueidentifier   = null ,

	@PageSettings image   = null ,

	@LastUpdatedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [PathId]
	, [UserId]
	, [PageSettings]
	, [LastUpdatedDate]
    FROM
	[dbo].[aspnet_PersonalizationPerUser]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([PathId] = @PathId OR @PathId IS NULL)
	AND ([UserId] = @UserId OR @UserId IS NULL)
	AND ([LastUpdatedDate] = @LastUpdatedDate OR @LastUpdatedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [PathId]
	, [UserId]
	, [PageSettings]
	, [LastUpdatedDate]
    FROM
	[dbo].[aspnet_PersonalizationPerUser]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([PathId] = @PathId AND @PathId is not null)
	OR ([UserId] = @UserId AND @UserId is not null)
	OR ([LastUpdatedDate] = @LastUpdatedDate AND @LastUpdatedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

