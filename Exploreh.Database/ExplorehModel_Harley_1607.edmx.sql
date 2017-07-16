
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/16/2017 13:28:13
-- Generated from EDMX file: C:\01-PROJETOS HARLEY\02-Exploreh\Exploreh.Database\ExplorehModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [exploreh];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CidadeUnidadeFederacaoFK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblCidade] DROP CONSTRAINT [FK_CidadeUnidadeFederacaoFK];
GO
IF OBJECT_ID(N'[dbo].[FK_CidadeClienteEndereco]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteEndereco] DROP CONSTRAINT [FK_CidadeClienteEndereco];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteClienteEndereco]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteEndereco] DROP CONSTRAINT [FK_ClienteClienteEndereco];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteClienteTelefone]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteTelefone] DROP CONSTRAINT [FK_ClienteClienteTelefone];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteContatoCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteContato] DROP CONSTRAINT [FK_ClienteContatoCliente];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilTela_Perfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerfilTela] DROP CONSTRAINT [FK_PerfilTela_Perfil];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilTela_Tela]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerfilTela] DROP CONSTRAINT [FK_PerfilTela_Tela];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioPerfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_UsuarioPerfil];
GO
IF OBJECT_ID(N'[dbo].[FK_UnidadeFederacaoPaisFK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblUnidadeFederacao] DROP CONSTRAINT [FK_UnidadeFederacaoPaisFK];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cliente];
GO
IF OBJECT_ID(N'[dbo].[ClienteContato]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteContato];
GO
IF OBJECT_ID(N'[dbo].[ClienteEndereco]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteEndereco];
GO
IF OBJECT_ID(N'[dbo].[ClienteTelefone]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteTelefone];
GO
IF OBJECT_ID(N'[dbo].[Perfil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perfil];
GO
IF OBJECT_ID(N'[dbo].[PerfilTela]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PerfilTela];
GO
IF OBJECT_ID(N'[dbo].[TblBairro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblBairro];
GO
IF OBJECT_ID(N'[dbo].[TblCidade]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblCidade];
GO
IF OBJECT_ID(N'[dbo].[TblLogradouro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblLogradouro];
GO
IF OBJECT_ID(N'[dbo].[TblPais]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblPais];
GO
IF OBJECT_ID(N'[dbo].[TblUnidadeFederacao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblUnidadeFederacao];
GO
IF OBJECT_ID(N'[dbo].[Tela]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tela];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

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

-- Creating table 'ClienteContato'
CREATE TABLE [dbo].[ClienteContato] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [ClienteId] int  NOT NULL,
    [DataCadastro] datetime  NOT NULL,
    [DataAlteracao] datetime  NOT NULL,
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

-- Creating table 'Perfil'
CREATE TABLE [dbo].[Perfil] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Ativo] bit  NOT NULL,
    [DataCadastro] datetime  NOT NULL,
    [DataAlteracao] datetime  NULL
);
GO

-- Creating table 'PerfilTela'
CREATE TABLE [dbo].[PerfilTela] (
    [Perfil_Id] int  NOT NULL,
    [Tela_Id] int  NOT NULL,
    [DataCadastro] datetime  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'TblBairro'
CREATE TABLE [dbo].[TblBairro] (
    [IdBairro] int IDENTITY(1,1) NOT NULL,
    [IdCidade] int  NULL,
    [DcrChaveLocalidade] varchar(8)  NULL,
    [DcrChaveBairro] varchar(8)  NULL,
    [DcrNome] varchar(72)  NULL,
    [AbrevNome] varchar(36)  NULL,
    [DataReg] datetime  NULL,
    [EstReg] varchar(1)  NULL
);
GO

-- Creating table 'TblCidade'
CREATE TABLE [dbo].[TblCidade] (
    [IdCidade] int IDENTITY(1,1) NOT NULL,
    [IdUnidadeFederacao] int  NULL,
    [DcrSiglaPais] varchar(2)  NULL,
    [DcrSiglaUf] varchar(2)  NULL,
    [DcrChaveLocalidade] varchar(8)  NULL,
    [DcrNome] varchar(72)  NULL,
    [DcrCep] varchar(8)  NULL,
    [AbrevNome] varchar(36)  NULL,
    [TipLocalidade] varchar(1)  NULL,
    [SituacaoLocalidade] varchar(1)  NULL,
    [DataReg] datetime  NULL,
    [EstReg] varchar(1)  NULL
);
GO

-- Creating table 'TblLogradouro'
CREATE TABLE [dbo].[TblLogradouro] (
    [IdLogradouro] int IDENTITY(1,1) NOT NULL,
    [IdBairro] int  NULL,
    [DcrChaveBairroInicial] varchar(8)  NULL,
    [DcrChaveBairroFinal] varchar(8)  NULL,
    [DcrTipoLogradouro] varchar(26)  NULL,
    [DcrPreposicao] varchar(3)  NULL,
    [DcrTituloPatente] varchar(72)  NULL,
    [DcrChaveLogradouro] varchar(8)  NULL,
    [DcrNome] varchar(72)  NULL,
    [AbrevNome] varchar(72)  NULL,
    [DcrCep] varchar(8)  NULL,
    [DataReg] datetime  NULL,
    [EstReg] varchar(1)  NULL
);
GO

-- Creating table 'TblPais'
CREATE TABLE [dbo].[TblPais] (
    [IdPais] int IDENTITY(1,1) NOT NULL,
    [DcrSigla] varchar(2)  NULL,
    [DcrSigla2] varchar(3)  NULL,
    [DcrNome] varchar(72)  NULL,
    [AbrevNome] varchar(36)  NULL,
    [DataReg] datetime  NULL,
    [EstReg] varchar(1)  NULL
);
GO

-- Creating table 'TblUnidadeFederacao'
CREATE TABLE [dbo].[TblUnidadeFederacao] (
    [IdUnidadeFederacao] int IDENTITY(1,1) NOT NULL,
    [IdPais] int  NULL,
    [DcrSiglaPais] varchar(2)  NULL,
    [DcrSigla] varchar(2)  NULL,
    [DcrChaveUf] varchar(2)  NULL,
    [DcrNome] varchar(72)  NULL,
    [AbrevNome] varchar(36)  NULL,
    [DataReg] datetime  NULL,
    [EstReg] varchar(1)  NULL
);
GO

-- Creating table 'Tela'
CREATE TABLE [dbo].[Tela] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Ativo] bit  NOT NULL,
    [DataCadastro] datetime  NOT NULL,
    [DataAlteracao] datetime  NULL,
    [Descricao] nvarchar(max)  NULL
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
    [Senha] nvarchar(max)  NOT NULL,
    [PerfilId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [PK_Cliente]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClienteContato'
ALTER TABLE [dbo].[ClienteContato]
ADD CONSTRAINT [PK_ClienteContato]
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

-- Creating primary key on [Id] in table 'Perfil'
ALTER TABLE [dbo].[Perfil]
ADD CONSTRAINT [PK_Perfil]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PerfilTela'
ALTER TABLE [dbo].[PerfilTela]
ADD CONSTRAINT [PK_PerfilTela]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdBairro] in table 'TblBairro'
ALTER TABLE [dbo].[TblBairro]
ADD CONSTRAINT [PK_TblBairro]
    PRIMARY KEY CLUSTERED ([IdBairro] ASC);
GO

-- Creating primary key on [IdCidade] in table 'TblCidade'
ALTER TABLE [dbo].[TblCidade]
ADD CONSTRAINT [PK_TblCidade]
    PRIMARY KEY CLUSTERED ([IdCidade] ASC);
GO

-- Creating primary key on [IdLogradouro] in table 'TblLogradouro'
ALTER TABLE [dbo].[TblLogradouro]
ADD CONSTRAINT [PK_TblLogradouro]
    PRIMARY KEY CLUSTERED ([IdLogradouro] ASC);
GO

-- Creating primary key on [IdPais] in table 'TblPais'
ALTER TABLE [dbo].[TblPais]
ADD CONSTRAINT [PK_TblPais]
    PRIMARY KEY CLUSTERED ([IdPais] ASC);
GO

-- Creating primary key on [IdUnidadeFederacao] in table 'TblUnidadeFederacao'
ALTER TABLE [dbo].[TblUnidadeFederacao]
ADD CONSTRAINT [PK_TblUnidadeFederacao]
    PRIMARY KEY CLUSTERED ([IdUnidadeFederacao] ASC);
GO

-- Creating primary key on [Id] in table 'Tela'
ALTER TABLE [dbo].[Tela]
ADD CONSTRAINT [PK_Tela]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- Creating foreign key on [ClienteId] in table 'ClienteContato'
ALTER TABLE [dbo].[ClienteContato]
ADD CONSTRAINT [FK_ClienteContatoCliente]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Cliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteContatoCliente'
CREATE INDEX [IX_FK_ClienteContatoCliente]
ON [dbo].[ClienteContato]
    ([ClienteId]);
GO

-- Creating foreign key on [CidadeId] in table 'ClienteEndereco'
ALTER TABLE [dbo].[ClienteEndereco]
ADD CONSTRAINT [FK_CidadeClienteEndereco]
    FOREIGN KEY ([CidadeId])
    REFERENCES [dbo].[TblCidade]
        ([IdCidade])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CidadeClienteEndereco'
CREATE INDEX [IX_FK_CidadeClienteEndereco]
ON [dbo].[ClienteEndereco]
    ([CidadeId]);
GO

-- Creating foreign key on [Perfil_Id] in table 'PerfilTela'
ALTER TABLE [dbo].[PerfilTela]
ADD CONSTRAINT [FK_PerfilTela_Perfil]
    FOREIGN KEY ([Perfil_Id])
    REFERENCES [dbo].[Perfil]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilTela_Perfil'
CREATE INDEX [IX_FK_PerfilTela_Perfil]
ON [dbo].[PerfilTela]
    ([Perfil_Id]);
GO

-- Creating foreign key on [PerfilId] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [FK_UsuarioPerfil]
    FOREIGN KEY ([PerfilId])
    REFERENCES [dbo].[Perfil]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioPerfil'
CREATE INDEX [IX_FK_UsuarioPerfil]
ON [dbo].[Usuario]
    ([PerfilId]);
GO

-- Creating foreign key on [Tela_Id] in table 'PerfilTela'
ALTER TABLE [dbo].[PerfilTela]
ADD CONSTRAINT [FK_PerfilTela_Tela]
    FOREIGN KEY ([Tela_Id])
    REFERENCES [dbo].[Tela]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilTela_Tela'
CREATE INDEX [IX_FK_PerfilTela_Tela]
ON [dbo].[PerfilTela]
    ([Tela_Id]);
GO

-- Creating foreign key on [IdUnidadeFederacao] in table 'TblCidade'
ALTER TABLE [dbo].[TblCidade]
ADD CONSTRAINT [FK_CidadeUnidadeFederacaoFK]
    FOREIGN KEY ([IdUnidadeFederacao])
    REFERENCES [dbo].[TblUnidadeFederacao]
        ([IdUnidadeFederacao])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CidadeUnidadeFederacaoFK'
CREATE INDEX [IX_FK_CidadeUnidadeFederacaoFK]
ON [dbo].[TblCidade]
    ([IdUnidadeFederacao]);
GO

-- Creating foreign key on [IdPais] in table 'TblUnidadeFederacao'
ALTER TABLE [dbo].[TblUnidadeFederacao]
ADD CONSTRAINT [FK_UnidadeFederacaoPaisFK]
    FOREIGN KEY ([IdPais])
    REFERENCES [dbo].[TblPais]
        ([IdPais])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnidadeFederacaoPaisFK'
CREATE INDEX [IX_FK_UnidadeFederacaoPaisFK]
ON [dbo].[TblUnidadeFederacao]
    ([IdPais]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------