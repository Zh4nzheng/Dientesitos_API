USE [DB_Dientesitos]
GO
/****** Object:  Table [dbo].[CitaDental]    Script Date: 18/06/2023 08:00:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CitaDental](
	[IDCita] [int] IDENTITY(1,1) NOT NULL,
	[IDTratamiento] [int] NULL,
	[IDDoctor] [int] NULL,
	[IDPaciente] [int] NULL,
	[IDSede] [int] NULL,
	[Fecha] [date] NULL,
	[Hora] [time](0) NULL,
	[Duracion] [int] NULL,
	[ImportePagar] [decimal](5, 2) NULL,
	[Estado] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 18/06/2023 08:00:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[IDDoctor] [int] IDENTITY(1,1) NOT NULL,
	[Dni] [varchar](15) NULL,
	[Especialidad] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[ApellidoPaterno] [varchar](50) NULL,
	[ApellidoMaterno] [varchar](50) NULL,
	[NumeroColegioMedico] [varchar](50) NULL,
	[Constrasena] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDDoctor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 18/06/2023 08:00:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[IDFactura] [int] IDENTITY(1,1) NOT NULL,
	[IDCita] [int] NULL,
	[MetodoPago] [varchar](20) NULL,
	[Igv] [decimal](5, 2) NULL,
	[TotalPagar] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialMedico]    Script Date: 18/06/2023 08:00:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialMedico](
	[IDHistorial] [int] IDENTITY(1,1) NOT NULL,
	[IDPaciente] [int] NULL,
	[Alergias] [varchar](200) NULL,
	[Detalles] [varchar](200) NULL,
	[Resultado] [varchar](200) NULL,
	[Fecha] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDHistorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialMedico]    Script Date: 18/06/2023 08:00:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialMedico](
	[IDMaterial] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDMaterial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialTratamiento]    Script Date: 18/06/2023 08:00:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialTratamiento](
	[Cantidad] [int] NULL,
	[IDTratamiento] [int] NOT NULL,
	[IDMaterial] [int] NOT NULL,
 CONSTRAINT [PK_MaterialTratamiento] PRIMARY KEY CLUSTERED 
(
	[IDMaterial] ASC,
	[IDTratamiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicamento]    Script Date: 18/06/2023 08:00:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicamento](
	[IDMedicamento] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[UnidadMedida] [varchar](25) NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDMedicamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 18/06/2023 08:00:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[IDPaciente] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](15) NULL,
	[Nombre] [varchar](50) NULL,
	[ApellidoPaterno] [varchar](50) NULL,
	[ApellidoMaterno] [varchar](50) NULL,
	[Direccion] [varchar](100) NULL,
	[Constrasena] [varchar](100) NULL,
	[Telefono] [varchar](15) NULL,
	[Edad] [varchar](3) NULL,
	[Estado] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receta]    Script Date: 18/06/2023 08:00:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receta](
	[Cantidad] [int] NULL,
	[Dosis] [varchar](15) NULL,
	[IDCita] [int] NOT NULL,
	[IDMedicamento] [int] NOT NULL,
 CONSTRAINT [PK_Receta] PRIMARY KEY CLUSTERED 
(
	[IDCita] ASC,
	[IDMedicamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sede]    Script Date: 18/06/2023 08:00:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sede](
	[IDSede] [int] IDENTITY(1,1) NOT NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [varchar](15) NULL,
	[Gerente] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDSede] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tratamiento]    Script Date: 18/06/2023 08:00:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tratamiento](
	[IDTratamiento] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](200) NULL,
	[Duracion] [int] NULL,
	[Precio] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDTratamiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CitaDental] ON 
GO
INSERT [dbo].[CitaDental] ([IDCita], [IDTratamiento], [IDDoctor], [IDPaciente], [IDSede], [Fecha], [Hora], [Duracion], [ImportePagar], [Estado]) VALUES (1, 1, 1, 1, 1, CAST(N'2023-06-17' AS Date), CAST(N'12:05:06' AS Time), 3, CAST(10.00 AS Decimal(5, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[CitaDental] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctor] ON 
GO
INSERT [dbo].[Doctor] ([IDDoctor], [Dni], [Especialidad], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [NumeroColegioMedico], [Constrasena]) VALUES (1, N'12345678', N'Ortodoncia', N'Cañon', N'Noches', N'Luna', N'12345', N'prueba')
GO
INSERT [dbo].[Doctor] ([IDDoctor], [Dni], [Especialidad], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [NumeroColegioMedico], [Constrasena]) VALUES (2, N'87656733', N'Extraccion', N'daniel', N'madrugada', N'Luna', N'234442', N'prueba1')
GO
SET IDENTITY_INSERT [dbo].[Doctor] OFF
GO
SET IDENTITY_INSERT [dbo].[Paciente] ON 
GO
INSERT [dbo].[Paciente] ([IDPaciente], [Documento], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Direccion], [Constrasena], [Telefono], [Edad], [Estado]) VALUES (1, N'73456823', N'andre', N'chumbiraico', N'martinez', N'ate', N'prueba', N'987654320', N'28', 1)
GO
INSERT [dbo].[Paciente] ([IDPaciente], [Documento], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Direccion], [Constrasena], [Telefono], [Edad], [Estado]) VALUES (2, N'74893394', N'ricar', N'chumbi', N'arjona', N'ate', N'prueba1', N'989888833', N'25', 1)
GO
INSERT [dbo].[Paciente] ([IDPaciente], [Documento], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Direccion], [Constrasena], [Telefono], [Edad], [Estado]) VALUES (3, N'76478234', N'juan', N'nolasco', N'arjona', N'ate', N'prueba2', N'989888845', N'20', 1)
GO
INSERT [dbo].[Paciente] ([IDPaciente], [Documento], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Direccion], [Constrasena], [Telefono], [Edad], [Estado]) VALUES (4, N'76478345', N'daniel', N'diaz', N'arjona', N'ate', N'prueba2', N'98988834', N'59', 1)
GO
SET IDENTITY_INSERT [dbo].[Paciente] OFF
GO
SET IDENTITY_INSERT [dbo].[Sede] ON 
GO
INSERT [dbo].[Sede] ([IDSede], [Direccion], [Telefono], [Gerente]) VALUES (1, N'Av. Campanita, Pixie Hollow, País de nunca jamás', N'+1 234 567 890', N'Dr. Cañón Noches')
GO
INSERT [dbo].[Sede] ([IDSede], [Direccion], [Telefono], [Gerente]) VALUES (2, N'123 Calle Elm, Springfield', N'(555) 123-4567', N'Dr. Emmett Brown')
GO
INSERT [dbo].[Sede] ([IDSede], [Direccion], [Telefono], [Gerente]) VALUES (3, N'42 Baker Street, Londres', N'(555) 987-6543', N'Sherlock Holmes')
GO
INSERT [dbo].[Sede] ([IDSede], [Direccion], [Telefono], [Gerente]) VALUES (4, N'221B Calle del Crimen, Gotham City', N'(555) 246-8139', N'Dr. Harleen Quinzel')
GO
INSERT [dbo].[Sede] ([IDSede], [Direccion], [Telefono], [Gerente]) VALUES (5, N'742 Evergreen Terrace, Springfield', N'(555) 369-8520', N'Dr. Gregory House')
GO
INSERT [dbo].[Sede] ([IDSede], [Direccion], [Telefono], [Gerente]) VALUES (6, N'1600 Pennsylvania Avenue, Washington, D.C.', N'(555) 135-7904', N'Dr. Meredith Grey')
GO
SET IDENTITY_INSERT [dbo].[Sede] OFF
GO
SET IDENTITY_INSERT [dbo].[Tratamiento] ON 
GO
INSERT [dbo].[Tratamiento] ([IDTratamiento], [Nombre], [Descripcion], [Duracion], [Precio]) VALUES (1, N'Examen dental', N'Se revisa la boca, los dientes, las encías y las estructuras relacionadas para detectar cualquier problema dental o afecciones bucales.', 40, CAST(50.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[Tratamiento] ([IDTratamiento], [Nombre], [Descripcion], [Duracion], [Precio]) VALUES (2, N'Limpieza dental', N'Procedimiento en el cual el dentista elimina la placa y el sarro de los dientes, además de pulir su superficie.', 40, CAST(80.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[Tratamiento] ([IDTratamiento], [Nombre], [Descripcion], [Duracion], [Precio]) VALUES (3, N'Blanqueamiento dental', N'Procedimiento estético que busca aclarar el tono de los dientes, eliminando manchas y decoloraciones.', 60, CAST(500.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[Tratamiento] ([IDTratamiento], [Nombre], [Descripcion], [Duracion], [Precio]) VALUES (4, N'Tratamiento de caries y empastes', N'El tratamiento de caries y empastes implica la remoción del tejido dental dañado por la caries y la colocación de un empaste dental para restaurar la función y forma del diente.', 40, CAST(100.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[Tratamiento] ([IDTratamiento], [Nombre], [Descripcion], [Duracion], [Precio]) VALUES (5, N'Endodoncia y tratamientos de conducto', N'La endodoncia es un tratamiento necesario cuando la pulpa del diente está infectada o dañada. Implica la remoción de la pulpa y la posterior limpieza y sellado de los conductos radiculares.', 60, CAST(500.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[Tratamiento] ([IDTratamiento], [Nombre], [Descripcion], [Duracion], [Precio]) VALUES (6, N'Extraccion dental', N'Procedimiento en el cual se retiran los dientes dañados, infectados o problemáticos.', 40, CAST(100.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[Tratamiento] ([IDTratamiento], [Nombre], [Descripcion], [Duracion], [Precio]) VALUES (7, N'Ortodoncia y alineadores transparentes', N'Se revisa la boca, los dientes, las encías y las estructuras relacionadas para detectar cualquier problema dental o afecciones bucales.', 60, CAST(900.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[Tratamiento] ([IDTratamiento], [Nombre], [Descripcion], [Duracion], [Precio]) VALUES (8, N'Sesion Ortodoncia', N'Revision de la ortodoncia', 40, CAST(200.00 AS Decimal(5, 2)))
GO
INSERT [dbo].[Tratamiento] ([IDTratamiento], [Nombre], [Descripcion], [Duracion], [Precio]) VALUES (9, N'Implantes dentales', N'Tratamiento para reemplazar dientes perdidos. Implican la colocación de un implante de titanio en el hueso de la mandíbula y la posterior colocación de una corona dental sobre el implante.', 60, CAST(900.00 AS Decimal(5, 2)))
GO
SET IDENTITY_INSERT [dbo].[Tratamiento] OFF
GO
ALTER TABLE [dbo].[CitaDental]  WITH CHECK ADD FOREIGN KEY([IDDoctor])
REFERENCES [dbo].[Doctor] ([IDDoctor])
GO
ALTER TABLE [dbo].[CitaDental]  WITH CHECK ADD FOREIGN KEY([IDSede])
REFERENCES [dbo].[Sede] ([IDSede])
GO
ALTER TABLE [dbo].[CitaDental]  WITH CHECK ADD FOREIGN KEY([IDTratamiento])
REFERENCES [dbo].[Tratamiento] ([IDTratamiento])
GO
ALTER TABLE [dbo].[CitaDental]  WITH CHECK ADD  CONSTRAINT [fk_cita_paciente] FOREIGN KEY([IDPaciente])
REFERENCES [dbo].[Paciente] ([IDPaciente])
GO
ALTER TABLE [dbo].[CitaDental] CHECK CONSTRAINT [fk_cita_paciente]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD FOREIGN KEY([IDCita])
REFERENCES [dbo].[CitaDental] ([IDCita])
GO
ALTER TABLE [dbo].[HistorialMedico]  WITH CHECK ADD  CONSTRAINT [fk_historia_paciente] FOREIGN KEY([IDPaciente])
REFERENCES [dbo].[Paciente] ([IDPaciente])
GO
ALTER TABLE [dbo].[HistorialMedico] CHECK CONSTRAINT [fk_historia_paciente]
GO
ALTER TABLE [dbo].[MaterialTratamiento]  WITH CHECK ADD  CONSTRAINT [FK_MaterialDetall] FOREIGN KEY([IDMaterial])
REFERENCES [dbo].[MaterialMedico] ([IDMaterial])
GO
ALTER TABLE [dbo].[MaterialTratamiento] CHECK CONSTRAINT [FK_MaterialDetall]
GO
ALTER TABLE [dbo].[MaterialTratamiento]  WITH CHECK ADD  CONSTRAINT [FK_TratamientoDetall] FOREIGN KEY([IDTratamiento])
REFERENCES [dbo].[Tratamiento] ([IDTratamiento])
GO
ALTER TABLE [dbo].[MaterialTratamiento] CHECK CONSTRAINT [FK_TratamientoDetall]
GO
ALTER TABLE [dbo].[Receta]  WITH CHECK ADD  CONSTRAINT [FK_Receta_Cita] FOREIGN KEY([IDCita])
REFERENCES [dbo].[CitaDental] ([IDCita])
GO
ALTER TABLE [dbo].[Receta] CHECK CONSTRAINT [FK_Receta_Cita]
GO
ALTER TABLE [dbo].[Receta]  WITH CHECK ADD  CONSTRAINT [FK_Receta_Medicamen] FOREIGN KEY([IDMedicamento])
REFERENCES [dbo].[Medicamento] ([IDMedicamento])
GO
ALTER TABLE [dbo].[Receta] CHECK CONSTRAINT [FK_Receta_Medicamen]
GO
