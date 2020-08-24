# clientapp

## Go To

root/CodingActivity.WebApiVue/clientapp

## Project Vue setup
```
npm install
```

### Compiles and hot-reloads for development
```
npm run serve
```

### Compiles and minifies for production
```
npm run build
```

### Run your tests
```
npm run test
```

### Lints and fixes files
```
npm run lint
```

## Go To

root/CodingActivity.WebApiVue

## Project WebApi setup
```
dotnet built
dotnet run
```

## Note

If you are going to run the VueApp in a different url you need to go **Startup.cs** file:
```
services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("VueAppUrl")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});
```

### Customize configuration
See [Configuration Reference](https://cli.vuejs.org/config/).
