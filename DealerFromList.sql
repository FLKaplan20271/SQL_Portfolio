SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DealerFromList] 
	-- Add the parameters for the stored procedure here
	@IncludeList NVARCHAR(200) = NULL,
	@ExcludeList NVARCHAR(200) = NULL,
	@TextSearch NVARCHAR(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @SQL NVARCHAR(2000);

	SET @SQL = 'SELECT TOP 5000 * FROM Dealer WHERE RecordType >= 0';

	IF LTRIM(@IncludeList)='' SET @IncludeList = NULL;
	IF LTRIM(@ExcludeList)='' SET @ExcludeList = NULL;

	IF @IncludeList IS NOT NULL
	BEGIN
		SET @IncludeList = REPLACE(@IncludeList,'''','''''');
		SET @IncludeList = REPLACE(@IncludeList,',',''',''');
		SET @SQL = @SQL +  ' AND (FMCCode IN ('''+@IncludeList+''') OR DealerID IN ('''+@IncludeList+'''))'
	END;

	IF @ExcludeList IS NOT NULL
	BEGIN
		SET @ExcludeList = REPLACE(@ExcludeList,'''','''''');
		SET @ExcludeList = REPLACE(@ExcludeList,',',''',''');
		SET @SQL = @SQL +  ' AND ISNULL(FMCCode,''.xxxx.'') NOT IN ('''+@ExcludeList+''') AND ISNULL(DealerID,''.xxxx.'') NOT IN ('''+@ExcludeList+''')'
	END;

	IF @TextSearch IS NOT NULL
	BEGIN
		SET @TextSearch = REPLACE(@TextSearch,'''','''''');
		SET @SQL = @SQL +  ' AND ISNULL(Name,'''')+''|''+'
							+ 'ISNULL(Address,'''')+''|''+'
							+ 'ISNULL(City,'''')+''|''+'
							+ 'ISNULL(State,'''')+''|''+'
							+ 'ISNULL(Zip,'''')+''|''+'
							+ 'ISNULL(GeoAddress,'''')+''|'' '
							+ ' LIKE ''%'+@TextSearch+'%''';
	END;

	SET @SQL = @SQL + ' ORDER BY ModelYear, ProdDate, FMCCode'

	PRINT @SQL


	EXEC sp_sqlexec @SQL;
END
GO
