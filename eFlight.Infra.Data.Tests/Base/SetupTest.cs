using Xunit;

namespace ProjectsPortifolio.Infra.Data.Tests.Base
{
    [Collection("Database collection")]
    public class SetupTest
    {

    }
    [Collection("Database collection")]
    public class DatabaseCollection : SetupTest
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}