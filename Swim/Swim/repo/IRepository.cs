using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripApp.repo
{
    // CRUD operations repository interface
    // where E is a type of entity saved in repository
    // and ID is a type E must have an attribute of type ID
    public interface IRepository<ID, E> where E : domain.Entity<ID>
    {
        // returns the entity with the specified id
        // or null if there is no entity with the given id
        // throws an IllegalArgumentException if id is null.
        E? FindOne(ID id);

        // returns all entities
        IEnumerable<E> FindAll();

        // saves the given entity
        // returns null if the entity is saved, otherwise returns the entity (id already exists)
        // throws an IllegalArgumentException if the given entity is null.
        bool Save(E entity);

        // removes the entity with the specified id
        // returns the removed entity or null if there is no entity with the given id
        // throws an IllegalArgumentException if the given id is null.
        bool Delete(ID id);

        // updates the given entity
        // returns null if the entity is updated, otherwise returns the entity (e.g. id does not exist)
        // throws an IllegalArgumentException if the given entity is null.
        bool Update(E entity);
    }
}

