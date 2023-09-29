--CREATE TABLE ANAGRAFICA (
--    IdAnagrafica INT PRIMARY KEY IDENTITY,
--    Cognome NVARCHAR(20),
--    Nome NVARCHAR(20),
--    Indirizzo NVARCHAR(50),
--    Citta NVARCHAR(20),
--    Cap INT,
--    CodiceFiscale NVARCHAR(16)
--)

--CREATE TABLE TIPOVIOLAZIONE (
--    IdViolazione INT PRIMARY KEY IDENTITY,
--    Descrizione NVARCHAR(50)
--)

--CREATE TABLE VERBALE (
--    IdVerbale INT PRIMARY KEY IDENTITY,
--    DataViolazione DATE,
--    IndirizzoViolazione NVARCHAR(50),
--    NominativoAgente NVARCHAR(20),
--    DataVerbale DATE,
--    Importo MONEY,
--    DecurtamentoPunti INT,
--    IdAnagrafica INT,
--    IdViolazione INT,
--    CONSTRAINT FK_ANAGRAFICA_VERBALE FOREIGN KEY (IdAnagrafica) REFERENCES ANAGRAFICA (IdAnagrafica),
--    CONSTRAINT FK_ANAGRAFICA_VIOLAZIONE FOREIGN KEY (IdViolazione) REFERENCES TIPOVIOLAZIONE (IdViolazione)
--)

--INSERT INTO ANAGRAFICA (Cognome, Nome, Indirizzo, Citta, Cap, CodiceFiscale)
--VALUES
--('Rossi', 'Mario', 'Via Italia', 'Roma', 00100, 'MRR12345'),
--('Rossi', 'Luigi', 'Via Francia', 'Milano', 00200, 'LGR33345'),
--('Cifarelli', 'Giuseppe', 'Via Matera', 'Matera', 75100, 'GPC99934'),
--('Baglio', 'Aldo', 'Via Tre', 'Palermo', 90100, 'LDB23456'),
--('Poretti', 'Giacomo', 'Via Zelig', 'Torino', 10024, 'GCP89892'),
--('Storti', 'Giovanni', 'Via Pdor', 'Istar', 23654, 'GNS45234'),
--('Brazorf', 'Ajeje', 'Via Pullman', 'Genova', 16100, 'JJB56243'),
--('Puccio', 'Marco', 'Via Server', 'Palermo', 90100, 'MCP56287'),
--('Manca', 'Paolo', 'Via Caprera', 'Pisa', 56100, 'PLM17890'),
--('Casasola', 'Stefano', 'Via Css', 'Gorizia', 74211, 'STC39393'),
--('Tedesco', 'Michele', 'Via Pirata', 'Bologna', 55165, 'MCT99999'),
--('Kovac', 'Lidia', 'Via Veloce', 'Genova', 16100, 'LDK11111'),
--('Baudo', 'Pippo', 'Via Ariston', 'Sanremo', 99876, 'PPB54545'),
--('Bongiorno', 'Mike','Via Gira La Ruota', 'Roma', 00100, 'MKB45453'),
--('Greggio', 'Ezio', 'Via Striscia', 'Milano', 00200, 'ZGR76543'),
--('Iacchetti', 'Enzo', 'Via La Notizia', 'Palermo', 90100, 'NZC23412')

--INSERT INTO TIPOVIOLAZIONE (Descrizione)
--VALUES
--('Eccesso di velocità'),
--('Passaggio con il rosso'),
--('Guida senza cintura'),
--('Parlare al telefono durante la guida'),
--('Sosta vietata'),
--('Guida in stato di ebbrezza'),
--('Guida senza patente'),
--('Mancata revisione')

--INSERT INTO VERBALE (DataViolazione, IndirizzoViolazione, NominativoAgente, DataVerbale, Importo, DecurtamentoPunti, IdAnagrafica, IdViolazione)
--VALUES
--('2020-10-15', 'Via Roma 4', 'Mazzetta', '2020-10-16', 100, 3, 1, 1),
--('2021-03-22', 'Via Garibaldi 5', 'Tangente', '2021-03-23', 50, 2, 2, 2),
--('2021-06-07', 'Corso Vittorio Emanuele 6', 'Pizzo', '2021-06-08', 75, 4, 1, 3),
--('2021-11-12', 'Via Caldo 38', 'Mazzetta', '2021-11-13', 90, 3, 5, 1),
--('2009-07-04', 'Via Freddo 2', 'Bustarella', '2009-12-05', 70, 2, 7, 2),
--('2022-02-19', 'Corso Vittorio Emanuele 9', 'Tangente', '2022-02-20', 110, 4, 8, 3),
--('2021-07-30', 'Via Roma 10', 'Mazzetta', '2021-07-31', 130, 5, 10, 6),
--('2008-09-05', 'Via Cavour 11', 'Bustarella', '2008-09-06', 75, 2, 2, 2),
--('2022-04-28', 'Corso Pasqua 12', 'Onesto', '2022-04-29', 95, 4, 3, 3),
--('2022-08-14', 'Via Pisa 13', 'Passacarte', '2022-08-15', 110, 5, 12, 6),
--('2010-10-25', 'Via Puccio 14', 'Bustarella', '2010-10-26', 500, 10, 16, 8),
--('2021-02-18', 'Via Del Campo 87', 'Mazzetta', '2021-02-19', 70, 5, 15, 6),
--('2022-05-09', 'Vicolo Corto 16', 'Bustarella', '2022-05-10', 120, 3, 14, 1),
--('2020-10-15', 'Via Bastioni Gran Sasso 98', 'Occhiosvelto', '2020-10-16', 55, 2, 11, 2),
--('2008-01-04', 'Corso Ateneo 18', 'Parente', '2008-01-05', 70, 4, 13, 3),
--('2022-10-20', 'Viale Monterosa 19', 'Bustarella', '2022-10-21', 110, 3, 9, 1),
--('2009-02-15', 'Piazza San Marco 20', 'Tangente', '2009-11-16', 85, 7, 4, 7),
--('2021-05-22', 'Corso Raffaello 21', 'Parente', '2021-05-23', 70, 4, 4, 3),
--('2022-01-14', 'Via Dei Giardini 32', 'Onesto', '2022-01-15', 120, 3, 6, 1),
--('2020-12-19', 'Via Marco Polo 23', 'Mazzetta', '2020-12-20', 55, 2, 1, 2),
--('2015-09-28', 'Corso Impero 24', 'Pizzo', '2015-09-29', 70, 10, 3, 8),
--('2022-03-11', 'Via Dei Coltelli 25', 'Pizzo', '2022-03-12', 500, 3, 10, 4),
--('2009-10-09', 'Piazza Stazione 26', 'Parente', '2020-10-10', 85, 2, 12, 2),
--('2021-08-27', 'Corso Italia 12', 'Mazzetta', '2021-08-28', 70, 4, 13, 3)


SELECT COUNT(*) AS TOTALEVERBALI FROM VERBALE

SELECT COGNOME, NOME, CITTA, COUNT(VERBALE.IDVERBALE) AS VERBALI FROM ANAGRAFICA LEFT JOIN VERBALE ON
ANAGRAFICA.IDANAGRAFICA = VERBALE.IDANAGRAFICA GROUP BY COGNOME, NOME, CITTA

SELECT DESCRIZIONE, COUNT(VERBALE.IDVERBALE) AS VERBALI FROM TIPOVIOLAZIONE LEFT JOIN VERBALE ON
TIPOVIOLAZIONE.IDVIOLAZIONE = VERBALE.IDVIOLAZIONE GROUP BY DESCRIZIONE

SELECT COGNOME, NOME, CITTA, SUM(DECURTAMENTOPUNTI) AS PUNTI FROM ANAGRAFICA LEFT JOIN VERBALE ON
ANAGRAFICA.IDANAGRAFICA = VERBALE.IDANAGRAFICA GROUP BY COGNOME, NOME, CITTA

SELECT COGNOME, NOME, DATAVIOLAZIONE, IMPORTO, DECURTAMENTOPUNTI FROM ANAGRAFICA LEFT JOIN VERBALE ON
ANAGRAFICA.IDANAGRAFICA = VERBALE.IDANAGRAFICA WHERE CITTA = 'PALERMO'

SELECT COGNOME, NOME, DATAVIOLAZIONE, IMPORTO, DECURTAMENTOPUNTI AS PUNTI FROM ANAGRAFICA LEFT JOIN VERBALE ON
ANAGRAFICA.IDANAGRAFICA = VERBALE.IDANAGRAFICA WHERE DATAVIOLAZIONE BETWEEN '2009-02-01' AND '2009-07-31'

SELECT COGNOME, NOME, CITTA, SUM(IMPORTO) AS IMPORTO FROM ANAGRAFICA LEFT JOIN VERBALE ON 
ANAGRAFICA.IDANAGRAFICA = VERBALE.IDANAGRAFICA GROUP BY COGNOME, NOME, CITTA

SELECT * FROM ANAGRAFICA WHERE CITTA = 'PALERMO'

SELECT NOMINATIVOAGENTE, COUNT(*) AS VERBALI FROM VERBALE GROUP BY NOMINATIVOAGENTE

SELECT COGNOME, NOME, DATAVIOLAZIONE, IMPORTO, DECURTAMENTOPUNTI AS PUNTI FROM ANAGRAFICA LEFT JOIN VERBALE ON
ANAGRAFICA.IDANAGRAFICA = VERBALE.IDANAGRAFICA WHERE DECURTAMENTOPUNTI > 5

SELECT COGNOME, NOME, DATAVIOLAZIONE, IMPORTO, DECURTAMENTOPUNTI AS PUNTI FROM ANAGRAFICA LEFT JOIN VERBALE ON
ANAGRAFICA.IDANAGRAFICA = VERBALE.IDANAGRAFICA WHERE IMPORTO > 400