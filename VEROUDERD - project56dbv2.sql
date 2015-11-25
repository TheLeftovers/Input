--
-- PostgreSQL database dump
--

-- Dumped from database version 9.4.5
-- Dumped by pg_dump version 9.4.5
-- Started on 2015-11-05 13:36:08

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- TOC entry 176 (class 3079 OID 11855)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2023 (class 0 OID 0)
-- Dependencies: 176
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 172 (class 1259 OID 16523)
-- Name: connections; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE connections (
    unit_id bigint NOT NULL,
    port character varying NOT NULL,
    value boolean NOT NULL,
    date date NOT NULL,
    "time" time without time zone NOT NULL
);


ALTER TABLE connections OWNER TO postgres;

--
-- TOC entry 173 (class 1259 OID 16529)
-- Name: events; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE events (
    unit_id bigint NOT NULL,
    port character varying NOT NULL,
    value boolean NOT NULL,
    date date NOT NULL,
    "time" time without time zone NOT NULL
);


ALTER TABLE events OWNER TO postgres;

--
-- TOC entry 174 (class 1259 OID 16535)
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
-- TOC entry 2024 (class 0 OID 0)
-- Dependencies: 174
-- Name: TABLE monitoring; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE monitoring IS 'lot of double values, not sure what to make the PK.';


--
-- TOC entry 175 (class 1259 OID 16541)
-- Name: positions; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE positions (
    unit_id bigint NOT NULL,
    rd_x double precision NOT NULL,
    rd_y double precision NOT NULL,
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
-- TOC entry 1896 (class 2606 OID 16548)
-- Name: connections_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY connections
    ADD CONSTRAINT connections_pkey PRIMARY KEY (date, "time", unit_id);


--
-- TOC entry 1898 (class 2606 OID 16550)
-- Name: events_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY events
    ADD CONSTRAINT events_pkey PRIMARY KEY (unit_id, date, "time");


--
-- TOC entry 1900 (class 2606 OID 16552)
-- Name: monitoring_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY monitoring
    ADD CONSTRAINT monitoring_pkey PRIMARY KEY (unit_id, type, begin_time, end_time);


--
-- TOC entry 1902 (class 2606 OID 16554)
-- Name: positions_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY positions
    ADD CONSTRAINT positions_pkey PRIMARY KEY (unit_id, date, "time");


--
-- TOC entry 2022 (class 0 OID 0)
-- Dependencies: 6
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2015-11-05 13:36:08

--
-- PostgreSQL database dump complete
--

