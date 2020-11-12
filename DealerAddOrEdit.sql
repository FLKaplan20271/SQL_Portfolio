SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DealerAddOrEdit]
@DealerID					VARCHAR(10),
@DealerNumber				VARCHAR(10),
@Brand						VARCHAR(5),
@ModelYear					INT,
@Name						VARCHAR(50),
@Address					VARCHAR(100),
@City						VARCHAR(50),
@State						VARCHAR(3),
@Zip						VARCHAR(10),
@Telephone					VARCHAR(20),
@Shipping					MONEY,
@ShipBy						VARCHAR(10),
@VIN						VARCHAR(20),
@Comments					VARCHAR(100),
@Model						VARCHAR(2),
@Shelby						VARCHAR(20),
@ProdDate					DATETIME,
@StartDate					DATETIME,
@EndDate					DATETIME,
@Years						INT,
@Year						INT,
@FMCStatus					VARCHAR(20),
@FMCFranchise				VARCHAR(10),
@FMCSalesCode				VARCHAR(50),
@FMCStartDate				VARCHAR(50),
@FMCEndDate					DATETIME,
@FMCCode					VARCHAR(50),
@Status						VARCHAR(50),
@Code						VARCHAR(50),
@AltAddress					VARCHAR(50),
@GeoAddress					VARCHAR(50),
@GeoCity					VARCHAR(50),
@GeoState					VARCHAR(50),
@GeoZip						VARCHAR(10),
@GeoCounty					VARCHAR(50),
@GeoLat						DECIMAL(9,6),
@GeoLon						DECIMAL(9,6),
@GeocodingCheckComplete		BIT,
@RecordType					VARCHAR(50)
AS
BEGIN
	UPDATE Dealer             
				SET    DealerID=ISNULL(@DealerID, DealerID)				
					  ,DealerNumber=ISNULL(@DealerNumber, DealerNumber)			
					  ,Brand=ISNULL(@Brand, Brand)			
					  ,ModelYear=ISNULL(@ModelYear, ModelYear)				
					  ,Name=ISNULL(@Name, Name)					
					  ,Address=	ISNULL(@Address, Address)				
					  ,City=ISNULL(@City, City)					
					  ,State=ISNULL(@State, State)					
					  ,Zip=	ISNULL(@Zip, Zip)					
					  ,Telephone=ISNULL(@Telephone, Telephone)				
					  ,Shipping=ISNULL(@Shipping, Shipping)				
					  ,ShipBy=ISNULL(@ShipBy, ShipBy)					
					  ,VIN=	ISNULL(@VIN, VIN)					
					  ,Comments=ISNULL(@Comments, Comments)				
					  ,Model=ISNULL(@Model, Model)					
					  ,Shelby=ISNULL(@Shelby, Shelby)					
					  ,ProdDate=ISNULL(@ProdDate, ProdDate)				
					  ,StartDate=ISNULL(@StartDate, StartDate)				
					  ,EndDate=ISNULL(@EndDate, EndDate)				
					  ,Years=ISNULL(@Years, Years)					
					  ,Year=ISNULL(@Year, Year)					
					  ,FMCStatus=ISNULL(@FMCStatus, FMCStatus)				
					  ,FMCFranchise=ISNULL(@FMCFranchise, FMCFranchise)			
					  ,FMCSalesCode=ISNULL(@FMCSalesCode, FMCSalesCode)			
					  ,FMCStartDate=ISNULL(@FMCStartDate, FMCStartDate)			
					  ,FMCEndDate=ISNULL(@FMCEndDate, FMCEndDate)				
					  ,FMCCode=ISNULL(@FMCCode, FMCCode)				
					  ,Status=ISNULL(@Status, Status)					
					  ,Code=ISNULL(@Code, Code)					
					  ,AltAddress=ISNULL(@AltAddress, AltAddress)				
					  ,GeoAddress=ISNULL(@GeoAddress, GeoAddress)				
					  ,GeoCity=ISNULL(@GeoCity, GeoCity)				
					  ,GeoState=ISNULL(@GeoState, GeoState)				
					  ,GeoZip=ISNULL(@GeoZip, GeoZip)					
					  ,GeoCounty=ISNULL(@GeoCounty, GeoCounty)				
					  ,GeoLat=ISNULL(@GeoLat, GeoLat)					
					  ,GeoLon=ISNULL(@GeoLon, GeoLon)					
					  ,GeocodingCheckComplete=ISNULL(@GeocodingCheckComplete, GeocodingCheckComplete)
					  ,RecordType=ISNULL(@RecordType, RecordType)
					  WHERE DealerID = @DealerID;
END;
GO
