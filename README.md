# **How to Add `com.alec.io` Package to Your Unity Project**  

This guide explains how to add the **`com.alec.io`** Unity package to your project using **Unity Package Manager (UPM)** via its GitHub repository.  

---

## **Installation Method 1: Using Unity Package Manager (UPM)**
### **Option A: Via Git URL**
1. Open your Unity project.
2. Go to **Window > Package Manager**.
3. Click the **+ (Add)** button in the top-left corner.
4. Select **"Add package from git URL..."**.
5. Enter the following URL:  
   ```
   https://github.com/alirkarimy/unity-io.git?path=Packages/com.alec.io
   ```
6. Press **Add** and wait for Unity to download and import the package.

### **Option B: Via `manifest.json` (Manual)**
1. Open your Unity project folder in a file explorer.
2. Navigate to:  
   ```
   /Packages/manifest.json
   ```
3. Add the following line under `"dependencies"`:  
   ```json
   {
     "dependencies": {
       "com.alec.io": "https://github.com/alirkarimy/unity-io.git?path=Packages/com.alec.io",
       ... (other dependencies)
     }
   }
   ```
4. Save the file and return to Unity. The package will automatically install.

---

## **Updating the Package**
- If installed via Git URL, Unity checks for updates when reopening the project.  
- To force an update, remove the package and re-add it, or modify the Git URL to include a specific tag/branch:  
  ```
  https://github.com/alirkarimy/unity-io.git?path=Packages/com.alec.io#v1.0.0
  ```

---

## **Troubleshooting**
- **"Package not found"**: Ensure the Git URL is correct and the repository is accessible.  
- **Authentication issues**: If the repo is private, use SSH (`git@github.com:alirkarimy/unity-io.git`) or a personal access token.  
- **Errors after import**: Try restarting Unity or clearing the Library folder.  


🚀 **Happy coding!**
