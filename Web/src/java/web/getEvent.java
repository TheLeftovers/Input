/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package web;

import java.sql.Date;
import java.sql.Time;
import java.util.ArrayList;
import java.util.List;
import javax.jws.WebService;
import javax.jws.WebMethod;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;

/**
 *
 * @author Johan Bos
 */
@WebService(serviceName = "getEvent")
public class getEvent {

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getUnitID")
    public ArrayList<Long> getUnitID() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<Long> units = new ArrayList<>();

        session.beginTransaction();
        List qunit = session.createSQLQuery("SELECT e.unit_id FROM events e").list();

        if (qunit != null) {
            units.addAll(qunit);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return units;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getPort")
    public ArrayList<String> getPort() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<String> ports = new ArrayList<>();

        session.beginTransaction();
        List qports = session.createSQLQuery("SELECT e.port FROM events e").list();

        if (qports != null) {
            ports.addAll(qports);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return ports;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getValue")
    public ArrayList<Boolean> getValue() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<Boolean> value = new ArrayList<>();

        session.beginTransaction();
        List qvalue = session.createSQLQuery("SELECT e.value FROM events e").list();

        if (qvalue != null) {
            value.addAll(qvalue);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return value;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getDate")
    public ArrayList<Date> getDate() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<Date> date = new ArrayList<>();

        session.beginTransaction();
        List qdate = session.createSQLQuery("SELECT e.date FROM events e").list();

        if (qdate != null) {
            date.addAll(qdate);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return date;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getTime")
    public ArrayList<Time> getTime() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<Time> time = new ArrayList<>();

        session.beginTransaction();
        List qtime = session.createSQLQuery("SELECT e.time FROM events e").list();

        if (qtime != null) {
            time.addAll(qtime);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return time;
    }

}
