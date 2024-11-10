using System;

namespace ProxyExample
{
    class Client
    {
        static void Main(string[] args)
        {
            // Use standard Proxy
            Subject proxy = new Proxy();
            proxy.Request();

            // Use AccessProxy with authorization check
            Subject accessProxy = new AccessProxy("user123");
            accessProxy.Request();

            Console.ReadLine();
        }
    }

    // "Subject" abstract class
    abstract class Subject
    {
        public abstract void Request();
    }

    // "RealSubject" class that performs the actual work
    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("RealSubject: Handling request.");
        }
    }

    // "Proxy" class that delegates to RealSubject
    class Proxy : Subject
    {
        private RealSubject realSubject;

        public override void Request()
        {
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }
            Console.WriteLine("Proxy: Delegating request to RealSubject.");
            realSubject.Request();
        }
    }

    // "AccessProxy" class with access control
    class AccessProxy : Subject
    {
        private RealSubject realSubject;
        private string username;

        public AccessProxy(string username)
        {
            this.username = username;
        }

        public override void Request()
        {
            if (AuthenticateUser())
            {
                if (realSubject == null)
                {
                    realSubject = new RealSubject();
                }
                Console.WriteLine("AccessProxy: Access granted. Delegating request to RealSubject.");
                realSubject.Request();
            }
            else
            {
                Console.WriteLine("AccessProxy: Access denied. Unauthorized user.");
            }
        }

        private bool AuthenticateUser()
        {
            // Example authentication logic
            return username == "user123";
        }
    }
}
