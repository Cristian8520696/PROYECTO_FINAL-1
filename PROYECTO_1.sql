CREATE TABLE ResearchResults (
    Id INT IDENTITY(1,1) PRIMARY KEY,           -- Identificador único
    Prompt NVARCHAR(MAX) NOT NULL,               -- Texto del prompt
    Result NVARCHAR(MAX) NOT NULL,               -- Resultado de la API
    QueryDate DATETIME DEFAULT GETDATE()          -- Fecha y hora de la consulta
