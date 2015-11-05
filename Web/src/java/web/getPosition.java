/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package web;

import java.util.ArrayList;
import java.util.List;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import org.hibernate.Criteria;
import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;
import org.hibernate.criterion.Restrictions;

/**
 *
 * @author Johan Bos
 */
@WebService(serviceName = "getPosition")
public class getPosition {

    /**
     * Web service operation
     */
    @WebMethod(operationName = "getUnitID")
    public ArrayList<Long> getUnitID() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();
		
		Session session = sessionFactory.getCurrentSession();
                ArrayList<Long> units = new ArrayList<Long>();
		
		try {
                    for(long id=14010206; id < 14100016; id=id+89809){
                    session.beginTransaction();
                    Positions dbPosition = (Positions) session.get(Positions.class, id);
                    
                    if(dbPosition != null){
                        units.add(dbPosition.getUnitId());
                        }
                    }	
			session.getTransaction().commit();
		}
		catch (HibernateException e) {
			e.printStackTrace();
			session.getTransaction().rollback();
		}
        return units;
    }
    
    /**
     * Web service operation
     */
    @WebMethod(operationName = "getSpeed")
    public ArrayList<Integer> getSpeed() {
        SessionFactory sessionFactory = new Configuration().configure().buildSessionFactory();
		
		Session session = sessionFactory.getCurrentSession();
                ArrayList<Integer> speeds = new ArrayList<Integer>();
		
	
                  try {
                    for(long id=14010206; id < 14100016; id=id+89809){
                    session.beginTransaction();
                    Positions dbPosition = (Positions) session.get(Positions.class, id);
                    
                    if(dbPosition != null){
                        speeds.add(dbPosition.getSpeed());
                        }
                    }	
			session.getTransaction().commit();
		}
		catch (HibernateException e) {
			e.printStackTrace();
			session.getTransaction().rollback();
		}
		
		
        return speeds;
    }
}
