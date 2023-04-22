# MailService
## NuGetPackage For Send Mail

# What is AOP Service
MethodInterceptor For Aspect Oriented Programming.
You Can Write Aspects With This MethodInterceptor.
Good luck in using NuGet Package.
 
- ✨Note
    * This NuGet Package can be used with .Net.



## Use Package

## .Net

* ExampleAspect.cs

  ```sh 
    public class ExampleAspect : MethodInterceptor
    {
        public Type Class { get; set; }
        public EfTransaction(Type _class)
        {
            Class = _class;
        }
        public override void OnBefore(IInvocation invocation)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    tran.Complete();
                }
                catch (SystemException ex)
                {
                    tran.Dispose();
                }
            }
        }
    }
```

