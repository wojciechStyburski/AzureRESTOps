IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
var configuration = configurationBuilder.AddConfiguration().Build();

ServiceCollection services = new();
services.AddCore(configuration);
services.AddSingleton<App>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<App>();
await app.Run(args);