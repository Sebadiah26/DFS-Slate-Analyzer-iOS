﻿using Microsoft.Extensions.Logging;

namespace SlateAnalyzer;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<IMap>(Map.Default);

        builder.Services.AddSingleton<ContestService>();
        builder.Services.AddSingleton<EntriesViewModel>();
        builder.Services.AddSingleton<EntriesPage>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<EntryDetailsViewModel>();
        builder.Services.AddTransient<DetailsPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
