/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package project.pkg56;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.List;
import javax.jws.WebService;
import javax.jws.WebMethod;
import org.hibernate.Criteria;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;
import org.hibernate.criterion.Restrictions;

/**
 *
 * @author Johan Bos
 */
@WebService(serviceName = "getPerson")
public class getPerson {

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "GetPerson")
    public String getPerson() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();
        Session session = sessionFactory.getCurrentSession();

        ArrayList<Person> persons = new ArrayList<>();

        session.beginTransaction();
        int pid = 0;

        for (pid = 1; pid < 5; pid++) {
            Criteria criteria = session.createCriteria(Person.class);
            criteria.add(Restrictions.eq("id", pid));
            Person dbPerson = (Person) criteria.uniqueResult();

            if (dbPerson != null) {
                //List result = criteria.list();
                persons.add(dbPerson);
            } else {
                return null;
            }
        }

        session.getTransaction().commit();
        return persons.toString();
    }
    
    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "GetID")
    public ArrayList<Integer> GetID() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();
        Session session = sessionFactory.getCurrentSession();

        ArrayList<Integer> pids = new ArrayList<>();

        session.beginTransaction();
        int pid = 0;

        for (pid = 1; pid < 5; pid++) {
            Criteria criteria = session.createCriteria(Person.class);
            criteria.add(Restrictions.eq("id", pid));
            Person dbPerson = (Person) criteria.uniqueResult();

            if (dbPerson != null) {
                //List result = criteria.list();
                pids.add(dbPerson.getId());
            } else {
                return null;
            }
        }

        session.getTransaction().commit();
        return pids;
    }
    
    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "GetHours")
    public ArrayList<Integer> GetHours() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();
        Session session = sessionFactory.getCurrentSession();

        ArrayList<Integer> hours = new ArrayList<>();

        session.beginTransaction();
        int pid = 0;

        for (pid = 1; pid < 5; pid++) {
            Criteria criteria = session.createCriteria(Person.class);
            criteria.add(Restrictions.eq("id", pid));
            Person dbPerson = (Person) criteria.uniqueResult();

            if (dbPerson != null) {
                //List result = criteria.list();
                hours.add(dbPerson.getHours());
            } else {
                return null;
            }
        }

        session.getTransaction().commit();
        return hours;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "GetFirstName")
    public ArrayList<String> GetFirstName() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();
        Session session = sessionFactory.getCurrentSession();

        ArrayList<String> fnames = new ArrayList<>();

        session.beginTransaction();
        int pid = 0;

        for (pid = 1; pid < 5; pid++) {
            Criteria criteria = session.createCriteria(Person.class);
            criteria.add(Restrictions.eq("id", pid));
            Person dbPerson = (Person) criteria.uniqueResult();

            if (dbPerson != null) {
                //List result = criteria.list();
                fnames.add(dbPerson.getFirstName());
            } else {
                return null;
            }
        }

        session.getTransaction().commit();
        return fnames;
    }

}
