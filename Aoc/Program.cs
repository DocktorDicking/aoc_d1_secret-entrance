
using Aoc;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Register services
services.AddSingleton<CombinationSafe>();
services.AddTransient<App>();

using var provider = services.BuildServiceProvider();

provider.GetRequiredService<App>().Run(args);