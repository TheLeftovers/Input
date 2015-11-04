--
-- PostgreSQL database dump
--

-- Dumped from database version 9.4.4
-- Dumped by pg_dump version 9.4.4
-- Started on 2015-11-04 11:57:47

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- TOC entry 177 (class 3079 OID 11855)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2029 (class 0 OID 0)
-- Dependencies: 177
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 173 (class 1259 OID 16538)
-- Name: connections; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE connections (
    date_time character varying NOT NULL,
    unit_id integer NOT NULL,
    port character varying NOT NULL,
    value boolean NOT NULL
);


ALTER TABLE connections OWNER TO postgres;

--
-- TOC entry 174 (class 1259 OID 16546)
-- Name: events; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE events (
    date_time character varying NOT NULL,
    unit_id integer NOT NULL,
    port character varying NOT NULL,
    value boolean NOT NULL
);


ALTER TABLE events OWNER TO postgres;

--
-- TOC entry 172 (class 1259 OID 16529)
-- Name: login; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE login (
    username character varying NOT NULL,
    password character varying NOT NULL,
    clearance character varying NOT NULL
);


ALTER TABLE login OWNER TO postgres;

--
-- TOC entry 175 (class 1259 OID 16554)
-- Name: monitoring; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE monitoring (
    unit_id integer NOT NULL,
    begin_time character varying NOT NULL,
    end_time character varying NOT NULL,
    type character varying NOT NULL,
    min integer NOT NULL,
    max integer NOT NULL,
    sum character varying NOT NULL
);


ALTER TABLE monitoring OWNER TO postgres;

--
-- TOC entry 2030 (class 0 OID 0)
-- Dependencies: 175
-- Name: TABLE monitoring; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE monitoring IS 'lot of double values, not sure what to make the PK.';


--
-- TOC entry 2031 (class 0 OID 0)
-- Dependencies: 175
-- Name: COLUMN monitoring.sum; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN monitoring.sum IS 'not sure if PostgreSQL sees 2.587E+08 as an integer so i used character varying.';


--
-- TOC entry 176 (class 1259 OID 16560)
-- Name: positions; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE positions (
    date_time character varying NOT NULL,
    unit_id integer NOT NULL,
    rd_x integer NOT NULL,
    rd_y integer NOT NULL,
    speed integer NOT NULL,
    course integer NOT NULL,
    num_satellites integer NOT NULL,
    hdop integer NOT NULL,
    quality character varying NOT NULL
);


ALTER TABLE positions OWNER TO postgres;

--
-- TOC entry 2018 (class 0 OID 16538)
-- Dependencies: 173
-- Data for Name: connections; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY connections (date_time, unit_id, port, value) FROM stdin;
\.


--
-- TOC entry 2019 (class 0 OID 16546)
-- Dependencies: 174
-- Data for Name: events; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY events (date_time, unit_id, port, value) FROM stdin;
\.


--
-- TOC entry 2017 (class 0 OID 16529)
-- Dependencies: 172
-- Data for Name: login; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY login (username, password, clearance) FROM stdin;
buyer	buyer	limited
test	test	full
\.


--
-- TOC entry 2020 (class 0 OID 16554)
-- Dependencies: 175
-- Data for Name: monitoring; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY monitoring (unit_id, begin_time, end_time, type, min, max, sum) FROM stdin;
\.


--
-- TOC entry 2021 (class 0 OID 16560)
-- Dependencies: 176
-- Data for Name: positions; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY positions (date_time, unit_id, rd_x, rd_y, speed, course, num_satellites, hdop, quality) FROM stdin;
\.


--
-- TOC entry 1903 (class 2606 OID 16545)
-- Name: connections_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY connections
    ADD CONSTRAINT connections_pkey PRIMARY KEY (date_time, unit_id);


--
-- TOC entry 1905 (class 2606 OID 16553)
-- Name: events_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY events
    ADD CONSTRAINT events_pkey PRIMARY KEY (date_time, unit_id);


--
-- TOC entry 1901 (class 2606 OID 16536)
-- Name: login_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY login
    ADD CONSTRAINT login_pkey PRIMARY KEY (username);


--
-- TOC entry 1907 (class 2606 OID 16567)
-- Name: positions_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY positions
    ADD CONSTRAINT positions_pkey PRIMARY KEY (date_time, unit_id);


--
-- TOC entry 2028 (class 0 OID 0)
-- Dependencies: 5
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2015-11-04 11:57:47

--
-- PostgreSQL database dump complete
--

