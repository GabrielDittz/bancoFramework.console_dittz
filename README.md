Meu primeiro projeto PDI(bancoframework.console) - c#

ScriptDB

CREATE TABLE [dbo].[Clientes](
	[Id] INT NOT NULL,
	[Nome] VARCHAR(70) NOT NULL,
	[CPF] CHAR(11) NOT NULL,
	[Saldo] FLOAT NOT NULL,

	CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED ([Id] ASC)
);