/* Computes the Greatest Common Denominator of
 * two positive integers. 
 */
static int gcd(int n1, int n2)
{
    if (n2 != 0)
        return gcd(n2, n1 % n2);
    else
        return n1;
}

/* Reduces a rational number represented by n1/n2
 * by computing the GCD of n1 and n2, then using it
 * to reduce the number to it's lowest form.
 */
static void reduce(ref int n1, ref int n2)
{
    int aN1 = n1 < 0 ? -n1 : n1;
    int aN2 = n2 < 0 ? -n2 : n2;

    int gcdNs = gcd(aN1, aN2);
    n1 = n1 / gcdNs;
    n2 = n2 / gcdNs;
}
