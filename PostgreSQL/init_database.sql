CREATE TABLE IF NOT EXISTS Stop (
    Id SERIAL PRIMARY KEY,
    Name TEXT NOT NULL,
    Latitude TEXT NOT NULL,
    Longitude TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Route (
    Id SERIAL PRIMARY KEY,
    Name TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS RouteStop (
    RouteId INTEGER NOT NULL,
    StopId INTEGER NOT NULL,
    CONSTRAINT fk_routeStop_route
        FOREIGN KEY(RouteId)
        REFERENCES Route(Id),
    CONSTRAINT fk_routeStop_stop
        FOREIGN KEY(StopId)
        REFERENCES Stop(Id)
);

CREATE TABLE IF NOT EXISTS Bus (
    Id INTEGER NOT NULL PRIMARY KEY,
    Name TEXT NOT NULL,
    Make TEXT NOT NULL,
    Driver TEXT,
    RouteId INTEGER NOT NULL,
    TotalBusCapacity INTEGER NOT NULL,
    CurrentBusOccupation INTEGER NOT NULL,
    Latitude TEXT NOT NULL,
    Longitude TEXT NOT NULL,
    CONSTRAINT fk_bus_route
        FOREIGN KEY(RouteId)
        REFERENCES Route(Id)
);

CREATE TABLE IF NOT EXISTS Ticket (
    Id SERIAL PRIMARY KEY,
    BusId INTEGER NOT NULL,
    PurchaseTime DATE NOT NULL,
    DepartureTime DATE NOT NULL,
    DepartureStopId INTEGER NOT NULL,
    DestinationStopId INTEGER NOT NULL,
    Price REAL NOT NULL,
    CONSTRAINT fk_ticket_stop_1
        FOREIGN KEY(DepartureStopId)
        REFERENCES Stop(Id),
    CONSTRAINT fk_ticket_stop_2
        FOREIGN KEY(DestinationStopId)
        REFERENCES Stop(Id)
);

CREATE TABLE IF NOT EXISTS Passenger (
    Id SERIAL PRIMARY KEY,
    Name TEXT
);

CREATE TABLE IF NOT EXISTS NFC (
    Id SERIAL PRIMARY KEY,
    UUID TEXT NOT NULL,
    PassengerId INTEGER NOT NULL,
    CONSTRAINT fk_nfc_passenger
        FOREIGN KEY(PassengerId)
        REFERENCES Passenger(Id)
);

CREATE TABLE IF NOT EXISTS FOB (
    Id SERIAL PRIMARY KEY,
    MacAddress TEXT NOT NULL,
    PassengerId INTEGER NOT NULL,
    CONSTRAINT fk_fob_passenger
        FOREIGN KEY(PassengerId)
        REFERENCES Passenger(Id)
);