--
-- PostgreSQL database dump
--

-- Dumped from database version 9.4.4
-- Dumped by pg_dump version 9.4.4
-- Started on 2015-11-25 15:52:16

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- TOC entry 178 (class 3079 OID 11855)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2031 (class 0 OID 0)
-- Dependencies: 178
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 172 (class 1259 OID 16505)
-- Name: connections; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE connections (
    unit_id bigint NOT NULL,
    port character varying NOT NULL,
    value boolean NOT NULL,
    date date NOT NULL,
    "time" time without time zone NOT NULL,
    conn_id integer NOT NULL
);


ALTER TABLE connections OWNER TO postgres;

--
-- TOC entry 177 (class 1259 OID 16628)
-- Name: connections_conn_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE connections_conn_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE connections_conn_id_seq OWNER TO postgres;

--
-- TOC entry 2032 (class 0 OID 0)
-- Dependencies: 177
-- Name: connections_conn_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE connections_conn_id_seq OWNED BY connections.conn_id;


--
-- TOC entry 173 (class 1259 OID 16511)
-- Name: events; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE events (
    unit_id bigint NOT NULL,
    port character varying NOT NULL,
    value boolean NOT NULL,
    date date NOT NULL,
    "time" time without time zone NOT NULL,
    event_id integer NOT NULL
);


ALTER TABLE events OWNER TO postgres;

--
-- TOC entry 176 (class 1259 OID 16616)
-- Name: events_event_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE events_event_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE events_event_id_seq OWNER TO postgres;

--
-- TOC entry 2033 (class 0 OID 0)
-- Dependencies: 176
-- Name: events_event_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE events_event_id_seq OWNED BY events.event_id;


--
-- TOC entry 174 (class 1259 OID 16523)
-- Name: monitoring; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE monitoring (
    unit_id bigint NOT NULL,
    type character varying NOT NULL,
    min bigint NOT NULL,
    max bigint NOT NULL,
    begin_time time without time zone NOT NULL,
    end_time time without time zone NOT NULL,
    sum bigint
);


ALTER TABLE monitoring OWNER TO postgres;

--
-- TOC entry 2034 (class 0 OID 0)
-- Dependencies: 174
-- Name: TABLE monitoring; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE monitoring IS 'lot of double values, not sure what to make the PK.';


--
-- TOC entry 175 (class 1259 OID 16529)
-- Name: positions; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE positions (
    unit_id bigint NOT NULL,
    rd_x integer NOT NULL,
    rd_y integer NOT NULL,
    speed integer NOT NULL,
    course integer NOT NULL,
    num_satellites integer NOT NULL,
    hdop integer NOT NULL,
    quality character varying NOT NULL,
    date date NOT NULL,
    "time" time without time zone NOT NULL
);


ALTER TABLE positions OWNER TO postgres;

--
-- TOC entry 1899 (class 2604 OID 16630)
-- Name: conn_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY connections ALTER COLUMN conn_id SET DEFAULT nextval('connections_conn_id_seq'::regclass);


--
-- TOC entry 1900 (class 2604 OID 16618)
-- Name: event_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY events ALTER COLUMN event_id SET DEFAULT nextval('events_event_id_seq'::regclass);


--
-- TOC entry 2018 (class 0 OID 16505)
-- Dependencies: 172
-- Data for Name: connections; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY connections (unit_id, port, value, date, "time", conn_id) FROM stdin;
\.


--
-- TOC entry 2035 (class 0 OID 0)
-- Dependencies: 177
-- Name: connections_conn_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('connections_conn_id_seq', 3751, true);


--
-- TOC entry 2019 (class 0 OID 16511)
-- Dependencies: 173
-- Data for Name: events; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY events (unit_id, port, value, date, "time", event_id) FROM stdin;
\.


--
-- TOC entry 2036 (class 0 OID 0)
-- Dependencies: 176
-- Name: events_event_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('events_event_id_seq', 2868, true);


--
-- TOC entry 2020 (class 0 OID 16523)
-- Dependencies: 174
-- Data for Name: monitoring; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY monitoring (unit_id, type, min, max, begin_time, end_time, sum) FROM stdin;
\.


--
-- TOC entry 2021 (class 0 OID 16529)
-- Dependencies: 175
-- Data for Name: positions; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY positions (unit_id, rd_x, rd_y, speed, course, num_satellites, hdop, quality, date, "time") FROM stdin;
\.


--
-- TOC entry 1902 (class 2606 OID 16638)
-- Name: connections_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY connections
    ADD CONSTRAINT connections_pkey PRIMARY KEY (conn_id);


--
-- TOC entry 1904 (class 2606 OID 16627)
-- Name: events_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY events
    ADD CONSTRAINT events_pkey PRIMARY KEY (event_id);


--
-- TOC entry 1906 (class 2606 OID 16594)
-- Name: monitoring_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY monitoring
    ADD CONSTRAINT monitoring_pkey PRIMARY KEY (unit_id, type, begin_time, end_time);


--
-- TOC entry 1908 (class 2606 OID 16603)
-- Name: positions_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY positions
    ADD CONSTRAINT positions_pkey PRIMARY KEY (unit_id, date, "time");


--
-- TOC entry 2030 (class 0 OID 0)
-- Dependencies: 6
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2015-11-25 15:52:16

--
-- PostgreSQL database dump complete
--

