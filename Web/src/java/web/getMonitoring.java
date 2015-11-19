/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package web;

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
@WebService(serviceName = "getMonitoring")
public class getMonitoring {

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
        List qunit = session.createSQLQuery("SELECT m.unit_id FROM monitoring m").list();

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
    @WebMethod(operationName = "getType")
    public ArrayList<String> getType() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<String> type = new ArrayList<>();

        session.beginTransaction();
        //List qspeed = session.createSQLQuery("SELECT p.speed FROM positions p WHERE p.unit_id IN (SELECT DISTINCT p.unit_id FROM positions p LIMIT 10) ORDER BY p.speed DESC LIMIT 10").list();
        List qtype = session.createSQLQuery("SELECT m.type FROM monitoring m").list();

        if (qtype != null) {
            type.addAll(qtype);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return type;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getMin")
    public ArrayList<Long> getMin() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<Long> min = new ArrayList<>();

        session.beginTransaction();
        List qmin = session.createSQLQuery("SELECT m.min FROM monitoring m").list();

        if (qmin != null) {
            min.addAll(qmin);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return min;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getMax")
    public ArrayList<Long> getMax() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<Long> max = new ArrayList<>();

        session.beginTransaction();
        List qmax = session.createSQLQuery("SELECT m.max FROM monitoring m").list();

        if (qmax != null) {
            max.addAll(qmax);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return max;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getBeginTime")
    public ArrayList<Time> getBeginTime() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<Time> begin = new ArrayList<>();

        session.beginTransaction();
        List qbegin = session.createSQLQuery("SELECT m.begin_time FROM monitoring m").list();

        if (qbegin != null) {
            begin.addAll(qbegin);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return begin;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getEndTime")
    public ArrayList<Time> getEndTime() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<Time> end = new ArrayList<>();

        session.beginTransaction();
        List qend = session.createSQLQuery("SELECT m.end_time FROM monitoring m").list();

        if (qend != null) {
            end.addAll(qend);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return end;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "getSum")
    public ArrayList<Long> getSum() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();

        Session session = sessionFactory.getCurrentSession();
        ArrayList<Long> sum = new ArrayList<>();

        session.beginTransaction();
        List qsum = session.createSQLQuery("SELECT m.sum FROM monitoring m").list();

        if (qsum != null) {
            sum.addAll(qsum);
        } else {
            return null;
        }

        session.getTransaction().commit();

        return sum;
    }

}
