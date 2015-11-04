/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package project.pkg56;

import java.util.ArrayList;
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
@WebService(serviceName = "getPositions")
public class getPositions {

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "GetPosition")
    public String getPosition() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();
        Session session = sessionFactory.getCurrentSession();

        ArrayList<Positions> positions = new ArrayList<>();

        session.beginTransaction();
        int pid = 0;

        for (pid = 1; pid < 5; pid++) {
            Criteria criteria = session.createCriteria(Positions.class);
            criteria.add(Restrictions.eq("id", pid));
            Positions dbPosition = (Positions) criteria.uniqueResult();

            if (dbPosition != null) {
                //List result = criteria.list();
                positions.add(dbPosition);
            } else {
                return null;
            }
        }

        session.getTransaction().commit();
        return positions.toString();
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "GetSpeed")
    public ArrayList<Integer> GetSpeed() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();
        Session session = sessionFactory.getCurrentSession();

        ArrayList<Integer> speed = new ArrayList<>();

        session.beginTransaction();
        int pid = 0;

        for (pid = 1; pid < 5; pid++) {
            Criteria criteria = session.createCriteria(Positions.class);
            criteria.add(Restrictions.eq("id", pid));
            Positions dbPosition = (Positions) criteria.uniqueResult();

            if (dbPosition != null) {
                //List result = criteria.list();
                speed.add(dbPosition.getSpeed());
            } else {
                return null;
            }
        }

        session.getTransaction().commit();
        return speed;
    }

    /**
     * Web service operation
     *
     * @return
     */
    @WebMethod(operationName = "GetUnitID")
    public ArrayList<Integer> GetUnitID() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();
        Session session = sessionFactory.getCurrentSession();

        ArrayList<Integer> units = new ArrayList<>();

        session.beginTransaction();
        int pid = 0;

        for (pid = 1; pid < 5; pid++) {
            Criteria criteria = session.createCriteria(Positions.class);
            criteria.add(Restrictions.eq("id", pid));
            Positions dbPositions = (Positions) criteria.uniqueResult();

            if (dbPositions != null) {
                //List result = criteria.list();
                units.add(dbPositions.positionsPK.getUnitId());
            } else {
                return null;
            }
        }

        session.getTransaction().commit();
        return units;
    }

}
