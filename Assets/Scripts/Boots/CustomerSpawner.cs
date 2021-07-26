using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    List<Customer> allCustomers = new List<Customer>();
    public Customer[] customerPrefabs;
    public Vector2 customerDir;

    public void SpawnCustomer(ColorType requestedColor)
    {
        Customer customerPrefab = customerPrefabs[Random.Range(0, customerPrefabs.Length - 1)];
        Customer newCustomer = Instantiate(customerPrefab);
        newCustomer.transform.parent = this.transform;
        newCustomer.transform.localPosition = Vector3.zero;
        newCustomer.SetUp(customerDir, requestedColor, this);
        allCustomers.Add(newCustomer);
    }

    public void RemoveCustomer(Customer customer)
    {
        if (!allCustomers.Contains(customer)) { return; }

        allCustomers.Remove(customer);
        StartCoroutine(DeleteCustomer(customer));
    }

    private IEnumerator DeleteCustomer(Customer customer)
    {
        yield return new WaitForSeconds(1f);
        Destroy(customer);
    }
}
