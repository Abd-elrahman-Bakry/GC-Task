using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalanceManager : MonoBehaviour
{

    public TextMeshProUGUI _yourBalanceText;


    private float _balance = 1000f;
    private string _message;

    private void Start()
    {
        _yourBalanceText.text=_balance.ToString();
    }


    public float Balance
    {
        get { return _balance; }
        set { _balance = Mathf.Max(0f, value); } // Constrain balance is not negative
    }


    // Increas your balance 
    public void IncreaseBalance(float amount)
    {
        if (amount >= 0)
            Balance += amount;
        else
            _message = "Please Enter Valid Message";
    }

    // Decrease your balance
    public void DecreaseBalance(float amount)
    {
        if (amount >= 0)
            Balance -= amount;
        else
            Balance = 0f;
    }

    void Update()
    {
        if (_balance >= 0f)
        {
            _yourBalanceText.text = _balance.ToString();
        }
        else {
            _yourBalanceText.text = "Please Withdraw From you Banck Acount";

        }
    }

   
}
