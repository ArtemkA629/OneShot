using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class AsyncOperationsExecutor
{
    public static async Task<AsyncOperationHandle<T>> Load<T>(AssetReference reference)
    {
        AsyncOperationHandle<T> handle = reference.LoadAssetAsync<T>();
        await handle.Task;
        if (handle.Status != AsyncOperationStatus.Succeeded)
            throw new Exception("Invalid operation handle.");
        return handle;
    }

    public static async Task<AsyncOperationHandle<T>[]> Load<T>(AssetReference[] references)
    {
        List<AsyncOperationHandle<T>> handles = new();
        foreach (var reference in references)
        {
            AsyncOperationHandle<T> handle = reference.LoadAssetAsync<T>();
            await handle.Task;
            if (handle.Status != AsyncOperationStatus.Succeeded)
                throw new Exception("Invalid operation handle.");
            handles.Add(handle);
        }

        return handles.ToArray();
    }
}
