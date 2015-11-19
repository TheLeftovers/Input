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
@WebService(serviceName = "getPosition")
public class getPosition {

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
        List qunit = session.createSQLQuery("SELECT p.unit_id FROM positions p").list();

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
    @WebMethod(operationName = "getSpeed")
    public ArrayList<Integer> getSpeed() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<Integer> speeds = new ArrayList<>();

        session.beginTransaction();
        //List qspeed = session.createSQLQuery("SELECT p.speed FROM positions p WHERE p.unit_id IN (SELECT DISTINCT p.unit_id FROM positions p LIMIT 10) ORDER BY p.speed DESC LIMIT 10").list();
        List qspeed = session.createSQLQuery("SELECT p.speed FROM positions p").list();

        if (qspeed != null) {
            speeds.addAll(qspeed);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return speeds;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getRDX")
    public ArrayList<Double> getRDX() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<Double> rdx = new ArrayList<>();

        session.beginTransaction();
        List qrdx = session.createSQLQuery("SELECT p.rd_x FROM positions p").list();

        if (qrdx != null) {
            rdx.addAll(qrdx);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return rdx;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getRDY")
    public ArrayList<Double> getRDY() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<Double> rdy = new ArrayList<>();

        session.beginTransaction();
        List qrdy = session.createSQLQuery("SELECT p.rd_y FROM positions p").list();

        if (qrdy != null) {
            rdy.addAll(qrdy);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return rdy;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getCourse")
    public ArrayList<Integer> getCourse() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<Integer> course = new ArrayList<>();

        session.beginTransaction();
        List qcourse = session.createSQLQuery("SELECT p.course FROM positions p").list();

        if (qcourse != null) {
            course.addAll(qcourse);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return course;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getNumSatellites")
    public ArrayList<Integer> getNumSatellites() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<Integer> sats = new ArrayList<>();

        session.beginTransaction();
        List qsats = session.createSQLQuery("SELECT p.num_satellites FROM positions p").list();

        if (qsats != null) {
            sats.addAll(qsats);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return sats;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getHDOP")
    public ArrayList<Integer> getHDOP() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<Integer> hdop = new ArrayList<>();

        session.beginTransaction();
        List qhdop = session.createSQLQuery("SELECT p.hdop FROM positions p").list();

        if (qhdop != null) {
            hdop.addAll(qhdop);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return hdop;
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
        List qdate = session.createSQLQuery("SELECT p.date FROM positions p").list();

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
        List qtime = session.createSQLQuery("SELECT p.time FROM positions p").list();

        if (qtime != null) {
            time.addAll(qtime);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return time;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getQuality")
    public ArrayList<String> getQuality() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<String> quality = new ArrayList<>();

        session.beginTransaction();
        List qquality = session.createSQLQuery("SELECT p.quality FROM positions p").list();

        if (qquality != null) {
            quality.addAll(qquality);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return quality;
    }
}
