using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BankAccountManager : MonoBehaviour
{
    public TextMeshProUGUI amountText;
    public TMP_InputField inputField;

    private float totalAmount = 3000f;
    BalanceManager balanceManager;
    void Start()
    {
        balanceManager = GetComponent<BalanceManager>();
        UpdateAmountText();
        amountText.text = "Total Amount: " + totalAmount.ToString();

    }


    //When Make Deposit from the account
    public void AddAmount()
    {
        float inputAmount = GetInputAmount();

        if (inputAmount > 0)
        {
            totalAmount += inputAmount;
            UpdateAmountText();
        }
    }


    //When Make Withdraw from the account
    public void WithdrawAmount()
    {
        float inputAmount = GetInputAmount();

        if (inputAmount > 0 && totalAmount - inputAmount >= 0)
        {
            totalAmount -= inputAmount;
            balanceManager.IncreaseBalance(inputAmount);
            UpdateAmountText();
        }
    }

    // When go to bed
    public void TenPercentincrease() {
        totalAmount += (totalAmount * 10) / 100;
        UpdateAmountText();
    }


    private void UpdateAmountText()
    {
        amountText.text = "Total Amount: " + totalAmount.ToString();
    }

    private float GetInputAmount()
    {
        float inputAmount;
        if (float.TryParse(inputField.text, out inputAmount))
        {
            return inputAmount;
        }

        return 0f; // Return 0 if the input is not a valid float
    }
}
