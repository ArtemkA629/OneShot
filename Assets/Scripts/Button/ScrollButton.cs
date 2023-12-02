public class ScrollButton : CustomButton<ScrollButtonType>
{
    public void Set(ScrollButtonType clickedButton)
    {
        bool isActive = clickedButton == ScrollButtonType.Right ? true : false;

        if (_argument == ScrollButtonType.Left)
            gameObject.SetActive(isActive);
        else
            gameObject.SetActive(!isActive);   
    }

    public void Appear()
    {
        gameObject.SetActive(true);
    }

    public void Disppear()
    {
        gameObject.SetActive(false);
    }
}
 