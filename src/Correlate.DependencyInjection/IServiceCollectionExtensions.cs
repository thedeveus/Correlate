﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Correlate.DependencyInjection
{
	/// <summary>
	/// Registration extensions for <see cref="IServiceCollection"/>.
	/// </summary>
	// ReSharper disable once InconsistentNaming
	public static class IServiceCollectionExtensions
	{
		/// <summary>
		/// Adds services required for using correlation.
		/// </summary>
		/// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
		/// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
		public static IServiceCollection AddCorrelate(this IServiceCollection services)
		{
			services.TryAddSingleton<ICorrelationContextAccessor, CorrelationContextAccessor>();
			services.TryAddTransient<ICorrelationContextFactory, CorrelationContextFactory>();
			services.TryAddSingleton<ICorrelationIdFactory, GuidCorrelationIdFactory>();
			services.TryAddSingleton<CorrelationManager>();

			return services;
		}
	}
}