# Azure Deployment Guide

This guide explains how to deploy the PersonalityTest application to Azure App Service with continuous deployment from GitHub.

## Prerequisites

- Azure account with active subscription
- GitHub account with the repository
- Azure CLI installed (optional)

## Step 1: Create Azure App Service

### Via Azure Portal

1. Log in to [Azure Portal](https://portal.azure.com)
2. Click **Create a resource** > **App Service**
3. Configure the basics:
   - **Subscription**: Select your subscription
   - **Resource Group**: Create new or select existing
   - **Name**: `personality-test-app`
   - **Runtime stack**: .NET 9
   - **Region**: Select nearest region
4. Click **Review + create** then **Create**

### Via Azure CLI

```bash
# Login to Azure
az login

# Create resource group
az group create --name personality-test-rg --location eastasia

# Create App Service plan
az appservice plan create --name personality-test-plan --resource-group personality-test-rg --sku B1

# Create web app
az webapp create --name personality-test-app --resource-group personality-test-rg --plan personality-test-plan --runtime "DOTNET|9.0"
```

## Step 2: Configure GitHub Deployment

### Via Azure Portal

1. Go to your App Service in Azure Portal
2. Navigate to **Deployment** > **Deployment center**
3. Select **Source**: GitHub
4. Authorize Azure to access your GitHub account
5. Select:
   - **Organization**: Your GitHub username
   - **Repository**: PersonalityTest
   - **Branch**: main
6. Click **Save**

### Via Azure CLI

```bash
# Configure GitHub deployment
az webapp deployment source config \
  --name personality-test-app \
  --resource-group personality-test-rg \
  --repo-url https://github.com/Khizar525/PersonalityTest \
  --branch main \
  --manual-integration
```

## Step 3: Enable Continuous Deployment

Once GitHub deployment is configured:

1. Every push to `main` branch triggers automatic deployment
2. Azure builds and deploys the application
3. Deployment status is visible in:
   - Azure Portal: Deployment center
   - GitHub: Actions tab

## Step 4: Configure Environment Variables

### Via Azure Portal

1. Go to **Configuration** in your App Service
2. Add **Application settings**:
   - `ASPNETCORE_ENVIRONMENT`: Production
   - `WEBSITES_PORT`: 80

### Via Azure CLI

```bash
az webapp config appsettings set \
  --name personality-test-app \
  --resource-group personality-test-rg \
  --settings ASPNETCORE_ENVIRONMENT=Production WEBSITES_PORT=80
```

## Step 5: Configure Custom Domain (Optional)

1. Buy a domain or use existing domain
2. In Azure Portal, go to **Custom domains**
3. Add your custom domain
4. Configure DNS records with your domain provider
5. Enable HTTPS with managed certificate

## Step 6: Enable Monitoring

### Application Insights

```bash
# Create Application Insights
az monitor app-insights component create \
  --app personality-test-insights \
  --location eastasia \
  --resource-group personality-test-rg

# Configure App Service to use Application Insights
az webapp config appsettings set \
  --name personality-test-app \
  --resource-group personality-test-rg \
  --settings APPINSIGHTS_INSTRUMENTATIONKEY=<your-key>
```

## Deployment Verification

1. Access your app: `https://personality-test-app.azurewebsites.net`
2. Test the personality test functionality
3. Check deployment logs in Azure Portal
4. Verify GitHub Actions workflow completed successfully

## Troubleshooting

### Common Issues

1. **Build fails**: Check .NET version compatibility
2. **Deployment fails**: Verify GitHub permissions
3. **App won't start**: Check application logs in Azure Portal

### View Logs

```bash
# Stream logs
az webapp log tail --name personality-test-app --resource-group personality-test-rg

# Download logs
az webapp log download --name personality-test-app --resource-group personality-test-rg
```

## Cost Optimization

- Use **Free tier** for development/testing
- Use **Basic tier** (B1) for production
- Enable **auto-scaling** for traffic spikes
- Set up **alerts** for resource usage

## Security Best Practices

1. Enable **HTTPS Only**
2. Configure **Authentication** if needed
3. Use **Managed Identity** for Azure resources
4. Enable **IP restrictions** if needed
5. Regular **security scanning**

## Next Steps

1. Set up **staging environment**
2. Configure **blue-green deployment**
3. Implement **feature flags**
4. Add **custom monitoring dashboards