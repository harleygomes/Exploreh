
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/11/2017 18:04:34
-- Generated from EDMX file: C:\Projetos\Exploreh\Exploreh\Exploreh.Database\ExplorehModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Exploreh];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EstadoCidade]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cidade] DROP CONSTRAINT [FK_EstadoCidade];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteClienteEndereco]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteEndereco] DROP CONSTRAINT [FK_ClienteClienteEndereco];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteClienteTelefone]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteTelefone] DROP CONSTRAINT [FK_ClienteClienteTelefone];
GO
IF OBJECT_ID(N'[dbo].[FK_CidadeClienteEndereco]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteEndereco] DROP CONSTRAINT [FK_CidadeClienteEndereco];
GO
IF OBJECT_ID(N'[dbo].[FK_EstadoClienteEndereco]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteEndereco] DROP CONSTRAINT [FK_EstadoClienteEndereco];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilTelas_Perfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerfilTelas] DROP CONSTRAINT [FK_PerfilTelas_Perfil];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilTelas_Telas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerfilTelas] DROP CONSTRAINT [FK_PerfilTelas_Telas];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioPerfil_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioPerfil] DROP CONSTRAINT [FK_UsuarioPerfil_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioPerfil_Perfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioPerfil] DROP CONSTRAINT [FK_UsuarioPerfil_Perfil];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cidade]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cidade];
GO
IF OBJECT_ID(N'[dbo].[Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cliente];
GO
IF OBJECT_ID(N'[dbo].[ClienteEndereco]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteEndereco];
GO
IF OBJECT_ID(N'[dbo].[ClienteTelefone]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteTelefone];
GO
IF OBJECT_ID(N'[dbo].[Estado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estado];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO
IF OBJECT_ID(N'[dbo].[Perfil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perfil];
GO
IF OBJECT_ID(N'[dbo].[Telas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Telas];
GO
IF OBJECT_ID(N'[dbo].[PerfilTelas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PerfilTelas];
GO
IF OBJECT_ID(N'[dbo].[UsuarioPerfil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioPerfil];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cidade'
CREATE TABLE [dbo].[Cidade] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(100)  NOT NULL,
    [CEP] nvarchar(50)  NOT NULL,
    [EstadoId] int  NOT NULL
);
GO

-- Creating table 'Cliente'
CREATE TABLE [dbo].[Cliente] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nchar(500)  NOT NULL,
    [TipoPessoa] nvarchar(50)  NOT NULL,
    [Documento] nvarchar(50)  NOT NULL,
    [Sexo] nvarchar(50)  NULL,
    [DataNascimento] datetime  NULL,
    [Ocupacao] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [HomePage] nvarchar(50)  NULL,
    [DataCadastro] datetime  NOT NULL,
    [DataAlteracao] datetime  NULL,
    [Ativo] bit  NOT NULL
);
GO

-- Creating table 'ClienteEndereco'
CREATE TABLE [dbo].[ClienteEndereco] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Logradouro] nvarchar(500)  NOT NULL,
    [Numero] nvarchar(50)  NOT NULL,
    [Complemento] nvarchar(50)  NULL,
    [Bairro] nvarchar(50)  NOT NULL,
    [DataCadastro] datetime  NOT NULL,
    [DataAlteracao] datetime  NULL,
    [Ativo] bit  NOT NULL,
    [ClienteId] int  NOT NULL,
    [CidadeId] int  NOT NULL,
    [EstadoId] int  NOT NULL,
    [CEP] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ClienteTelefone'
CREATE TABLE [dbo].[ClienteTelefone] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ddd] nvarchar(50)  NOT NULL,
    [Telefone] nvarchar(50)  NOT NULL,
    [DataCadastro] datetime  NOT NULL,
    [DataAlteracao] datetime  NULL,
    [Ativo] bit  NULL,
    [ClienteId] int  NOT NULL
);
GO

-- Creating table 'Estado'
CREATE TABLE [dbo].[Estado] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Sigla] nvarchar(50)  NOT NULL,
    [Nome] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NULL,
    [Ativo] bit  NOT NULL,
    [DataCadastro] datetime  NOT NULL,
    [DataAlteracao] datetime  NULL,
    [Senha] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Perfil'
CREATE TABLE [dbo].[Perfil] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Ativo] bit  NOT NULL,
    [DataCadastro] datetime  NOT NULL,
    [DataAlteracao] datetime  NULL
);
GO

-- Creating table 'Telas'
CREATE TABLE [dbo].[Telas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Ativo] bit  NOT NULL,
    [DataCadastro] datetime  NOT NULL,
    [DataAlteracao] datetime  NULL
);
GO

-- Creating table 'PerfilTelas'
CREATE TABLE [dbo].[PerfilTelas] (
    [Perfil_Id] int  NOT NULL,
    [Telas_Id] int  NOT NULL
);
GO

-- Creating table 'UsuarioPerfil'
CREATE TABLE [dbo].[UsuarioPerfil] (
    [Usuario_Id] int  NOT NULL,
    [Perfil_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Cidade'
ALTER TABLE [dbo].[Cidade]
ADD CONSTRAINT [PK_Cidade]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [PK_Cliente]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClienteEndereco'
ALTER TABLE [dbo].[ClienteEndereco]
ADD CONSTRAINT [PK_ClienteEndereco]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClienteTelefone'
ALTER TABLE [dbo].[ClienteTelefone]
ADD CONSTRAINT [PK_ClienteTelefone]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Estado'
ALTER TABLE [dbo].[Estado]
ADD CONSTRAINT [PK_Estado]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Perfil'
ALTER TABLE [dbo].[Perfil]
ADD CONSTRAINT [PK_Perfil]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Telas'
ALTER TABLE [dbo].[Telas]
ADD CONSTRAINT [PK_Telas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Perfil_Id], [Telas_Id] in table 'PerfilTelas'
ALTER TABLE [dbo].[PerfilTelas]
ADD CONSTRAINT [PK_PerfilTelas]
    PRIMARY KEY CLUSTERED ([Perfil_Id], [Telas_Id] ASC);
GO

-- Creating primary key on [Usuario_Id], [Perfil_Id] in table 'UsuarioPerfil'
ALTER TABLE [dbo].[UsuarioPerfil]
ADD CONSTRAINT [PK_UsuarioPerfil]
    PRIMARY KEY CLUSTERED ([Usuario_Id], [Perfil_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EstadoId] in table 'Cidade'
ALTER TABLE [dbo].[Cidade]
ADD CONSTRAINT [FK_EstadoCidade]
    FOREIGN KEY ([EstadoId])
    REFERENCES [dbo].[Estado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstadoCidade'
CREATE INDEX [IX_FK_EstadoCidade]
ON [dbo].[Cidade]
    ([EstadoId]);
GO

-- Creating foreign key on [ClienteId] in table 'ClienteEndereco'
ALTER TABLE [dbo].[ClienteEndereco]
ADD CONSTRAINT [FK_ClienteClienteEndereco]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Cliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteClienteEndereco'
CREATE INDEX [IX_FK_ClienteClienteEndereco]
ON [dbo].[ClienteEndereco]
    ([ClienteId]);
GO

-- Creating foreign key on [ClienteId] in table 'ClienteTelefone'
ALTER TABLE [dbo].[ClienteTelefone]
ADD CONSTRAINT [FK_ClienteClienteTelefone]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Cliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteClienteTelefone'
CREATE INDEX [IX_FK_ClienteClienteTelefone]
ON [dbo].[ClienteTelefone]
    ([ClienteId]);
GO

-- Creating foreign key on [CidadeId] in table 'ClienteEndereco'
ALTER TABLE [dbo].[ClienteEndereco]
ADD CONSTRAINT [FK_CidadeClienteEndereco]
    FOREIGN KEY ([CidadeId])
    REFERENCES [dbo].[Cidade]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CidadeClienteEndereco'
CREATE INDEX [IX_FK_CidadeClienteEndereco]
ON [dbo].[ClienteEndereco]
    ([CidadeId]);
GO

-- Creating foreign key on [EstadoId] in table 'ClienteEndereco'
ALTER TABLE [dbo].[ClienteEndereco]
ADD CONSTRAINT [FK_EstadoClienteEndereco]
    FOREIGN KEY ([EstadoId])
    REFERENCES [dbo].[Estado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstadoClienteEndereco'
CREATE INDEX [IX_FK_EstadoClienteEndereco]
ON [dbo].[ClienteEndereco]
    ([EstadoId]);
GO

-- Creating foreign key on [Perfil_Id] in table 'PerfilTelas'
ALTER TABLE [dbo].[PerfilTelas]
ADD CONSTRAINT [FK_PerfilTelas_Perfil]
    FOREIGN KEY ([Perfil_Id])
    REFERENCES [dbo].[Perfil]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Telas_Id] in table 'PerfilTelas'
ALTER TABLE [dbo].[PerfilTelas]
ADD CONSTRAINT [FK_PerfilTelas_Telas]
    FOREIGN KEY ([Telas_Id])
    REFERENCES [dbo].[Telas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilTelas_Telas'
CREATE INDEX [IX_FK_PerfilTelas_Telas]
ON [dbo].[PerfilTelas]
    ([Telas_Id]);
GO

-- Creating foreign key on [Usuario_Id] in table 'UsuarioPerfil'
ALTER TABLE [dbo].[UsuarioPerfil]
ADD CONSTRAINT [FK_UsuarioPerfil_Usuario]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[Usuario]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Perfil_Id] in table 'UsuarioPerfil'
ALTER TABLE [dbo].[UsuarioPerfil]
ADD CONSTRAINT [FK_UsuarioPerfil_Perfil]
    FOREIGN KEY ([Perfil_Id])
    REFERENCES [dbo].[Perfil]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioPerfil_Perfil'
CREATE INDEX [IX_FK_UsuarioPerfil_Perfil]
ON [dbo].[UsuarioPerfil]
    ([Perfil_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------