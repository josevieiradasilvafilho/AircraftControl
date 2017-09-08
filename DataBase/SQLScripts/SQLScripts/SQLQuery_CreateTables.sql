--AERONAVE
IF OBJECT_ID(N'[dbo].[tblAircraft]', N'U')  IS NOT NULL
	BEGIN
		DROP TABLE dbo.tblAircraft;
		CREATE TABLE [dbo].[tblAircraft](
			[ID_AIRCRAFT] [int] IDENTITY(1,1) NOT NULL,
			[PREFIX] [nvarchar](6) NOT NULL,
			[MAX_DEPARTURE_WEIGHT] [decimal] (9, 3) NOT NULL,
			[MAX_LANDING_WEIGHT] [decimal] (9, 3) NOT NULL,
			[PASSENGERS_COUNT] [int] NULL,
			[WINGSPAN] [decimal] (9, 2) NULL,
			[ACTIVE] [bit] NOT NULL,
			[ID_AIRCRAFTMODEL] [int] NOT NULL,
		CONSTRAINT [PK_tblAircraft] PRIMARY KEY CLUSTERED 
		(
		[ID_AIRCRAFT] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
END
ELSE
	BEGIN
		CREATE TABLE [dbo].[tblAircraft](
			[ID_AIRCRAFT] [int] IDENTITY(1,1) NOT NULL,
			[PREFIX] [nvarchar](6) NOT NULL,
			[MAX_DEPARTURE_WEIGHT] [decimal] (9, 3) NOT NULL,
			[MAX_LANDING_WEIGHT] [decimal] (9, 3) NOT NULL,
			[PASSENGERS_COUNT] [decimal] (9, 0) NOT NULL,
			[WINGSPAN] [decimal] (9, 2) NOT NULL,
			[ACTIVE] [bit] NOT NULL,
		CONSTRAINT [PK_tblAircraft] PRIMARY KEY CLUSTERED 
		(
		[ID_AIRCRAFT] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
END

--MODELO
IF OBJECT_ID(N'[dbo].[tblAircraftModel]', N'U')  IS NOT NULL
	BEGIN
		DROP TABLE dbo.tblAircraftModel;
		CREATE TABLE [dbo].[tblAircraftModel](
			[ID_AIRCRAFTMODEL] [int] IDENTITY(1,1) NOT NULL,
			[CODE] [decimal] (4, 0) NOT NULL,
			[ALTERNATIVE_CODE] [decimal] (4, 0) NULL,
			[MAX_DEPARTURE_WEIGHT] [decimal] (9, 3) NOT NULL,
			[MAX_LANDING_WEIGHT] [decimal] (9, 3) NOT NULL,
		CONSTRAINT [PK_tblAircraftModel] PRIMARY KEY CLUSTERED 
		(
		[ID_AIRCRAFTMODEL] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END
ELSE
	BEGIN
		CREATE TABLE [dbo].[tblAircraftModel](
			[ID_AIRCRAFTMODEL] [int] IDENTITY(1,1) NOT NULL,
			[CODE] [decimal] (4, 0) NOT NULL,
			[ALTERNATIVE_CODE] [decimal] (4, 0) NULL,
			[MAX_DEPARTURE_WEIGHT] [decimal] (9, 3) NOT NULL,
			[MAX_LANDING_WEIGHT] [decimal] (9, 3) NOT NULL,
		CONSTRAINT [PK_tblAircraftModel] PRIMARY KEY CLUSTERED 
		(
		[ID_AIRCRAFTMODEL] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	END

ALTER TABLE [dbo].[tblAircraft]  WITH CHECK ADD  CONSTRAINT [FK_tblAircraft_tblAircraftModel] FOREIGN KEY([ID_AIRCRAFTMODEL])
REFERENCES [dbo].[tblAircraftModel] ([ID_AIRCRAFTMODEL])
GO

ALTER TABLE [dbo].[tblAircraft] CHECK CONSTRAINT [FK_tblAircraft_tblAircraftModel]
GO