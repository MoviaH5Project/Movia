CREATE TABLE IF NOT EXISTS stop (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    latitude TEXT NOT NULL,
    longitude TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS route (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS routestop (
    routeid INTEGER NOT NULL,
    stopid INTEGER NOT NULL,
    CONSTRAINT fk_routeStop_route
        FOREIGN KEY(routeid)
        REFERENCES route(id),
    CONSTRAINT fk_routeStop_stop
        FOREIGN KEY(stopid)
        REFERENCES stop(id)
);

CREATE TABLE IF NOT EXISTS bus (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    make TEXT NOT NULL,
    driver TEXT,
    routeid INTEGER NOT NULL,
    totalbuscapacity INTEGER NOT NULL,
    currentbusoccupation INTEGER NOT NULL,
    latitude TEXT NOT NULL,
    longitude TEXT NOT NULL,
    CONSTRAINT fk_bus_route
        FOREIGN KEY(routeid)
        REFERENCES route(id)
);

CREATE TABLE IF NOT EXISTS passenger (
    id SERIAL PRIMARY KEY,
    name TEXT
);

CREATE TABLE IF NOT EXISTS nfc (
    id SERIAL PRIMARY KEY,
    uuid TEXT NOT NULL,
    passengerid INTEGER NOT NULL,
    CONSTRAINT fk_nfc_passenger
        FOREIGN KEY(passengerid)
        REFERENCES passenger(id)
);

CREATE TABLE IF NOT EXISTS fob (
    id SERIAL PRIMARY KEY,
    macaddress TEXT NOT NULL,
    passengerid INTEGER NOT NULL,
    CONSTRAINT fk_fob_passenger
        FOREIGN KEY(passengerid)
        REFERENCES passenger(id)
);

CREATE TABLE IF NOT EXISTS ticket (
    id SERIAL PRIMARY KEY,
    busid INTEGER NOT NULL,
    passengerid INTEGER NOT NULL,
    purchasetime TIMESTAMP NOT NULL,
    departuretime TIMESTAMP NOT NULL,
    departurestopid INTEGER NOT NULL,
    destinationstopid INTEGER NOT NULL,
    checkedout BOOLEAN NOT NULL,
    price REAL NOT NULL,
    CONSTRAINT fk_ticket_bus
        FOREIGN KEY(busid)
        REFERENCES bus(id),
    CONSTRAINT fk_ticket_passenger
        FOREIGN KEY(passengerid)
        REFERENCES passenger(id),
    CONSTRAINT fk_ticket_stop_1
        FOREIGN KEY(departurestopid)
        REFERENCES stop(id),
    CONSTRAINT fk_ticket_stop_2
        FOREIGN KEY(destinationstopid)
        REFERENCES stop(id)
);
