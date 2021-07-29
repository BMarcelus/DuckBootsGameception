using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    List<Customer> allCustomers = new List<Customer>();
    public Customer[] customerPrefabs;
    public Vector2 customerDir;

    BootsGameManager bgm;

    protected void Awake()
    {
        bgm = GetComponentInParent<BootsGameManager>();
    }

    public void SpawnCustomer(ColorType requestedColor)
    {
        Debug.Log("Spawn customer: " + requestedColor.ToString());
        Customer customerPrefab = customerPrefabs[Random.Range(0, customerPrefabs.Length - 1)];
        Customer newCustomer = Instantiate(customerPrefab);
        newCustomer.transform.parent = this.transform;
        newCustomer.transform.localPosition = Vector3.zero + new Vector3(0, 0.5f, 0);
        newCustomer.SetUp(customerDir, requestedColor, this);
        allCustomers.Add(newCustomer);
    }

    public void RemoveCustomer(Customer customer, bool isSatisfied)
    {
        if (!allCustomers.Contains(customer)) { return; }

        allCustomers.Remove(customer);
        StartCoroutine(DeleteCustomer(customer, isSatisfied));
    }

    private IEnumerator DeleteCustomer(Customer customer, bool isSatisfied)
    {
        yield return new WaitForSeconds(1f);
        bgm.OnCustomerRemove(isSatisfied);
        Destroy(customer.gameObject);
    }

    public void RemoveAllCustomers()
    {
        for (int i = 0; i < allCustomers.Count; i++)
        {
            Customer c = allCustomers[i];
            allCustomers.Remove(c);
            Destroy(c.gameObject);
        }
        
    }
}
