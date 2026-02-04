ProductMonitor - 工業物聯網監控儀表板

專案簡介 
這是一個使用WPF開發的工業監控系統原型。採用MVVM架構設計，盡量模擬真實工廠情境，具備即時數據監控、圖表分析。

這個是我第一個專案，爬了滿多教學WPF的影片跟書籍，加上Gemini，老實講就是跟著敲代碼，邊敲邊理解過程，主要還是以熟悉各個功能為主。

專案展示了如何使用C#整合Modbus TCP通訊協定，使用LiveCharts實現動態數據視覺化。

核心功能

1. 即時數據監控
環境監測：即時顯示光線、噪音、溫度、濕度等感測器數值。
智慧互動：滑鼠懸停於數據卡片 (如溫度) 上時，會透過ToolTip顯示即時歷史趨勢折線圖。
儀表板視覺化**：整合雷達圖與圓餅圖分析設備能耗與警報比例。

2. 工業通訊整合 
整合 `NModbus` 函式庫，實現 Modbus TCP Master 功能。
具備斷線偵測與錯誤處理機制，確保程式在通訊異常時不會崩潰。

3. 雙模式切換 
為了方便開發與演示，系統支援兩種數據來源模式，可於設定頁面動態切換：
真實模式：連接實際 IP:Port 的 PLC 或模擬器 (如 Modbus Slave)。
模擬模式 (Simulation Mode)：使用內建的 `MockDataService` 生成隨機數據，無需硬體即可展示所有功能。

4. 系統配置與架構
動態配置：提供圖形化設定介面，可即時修改目標 IP、Port 並切換模擬模式，無需重新編譯程式。
MVVM 架構**：嚴格遵守 Model-View-ViewModel 設計模式。
依賴注入 (DI)：透過 `IDataService` 介面解耦數據層，實現高可測試性與維護性。

技術棧 
語言：C# (.NET)
框架：WPF 
架構模式：MVVM
通訊協定：Modbus TCP (NModbus)
圖表庫：LiveCharts.Wpf
開發工具：Visual Studio 2026

專案結構 
* `Models/`: 定義數據模型 (e.g., `EnviromentModel`, `DeviceConfig`)。
* `ViewModels/`: 處理業務邏輯與數據綁定 (e.g., `MainWindowVM`, `SettingsVM`)。
* `Services/`: 數據服務層，包含真實通訊與模擬數據 (e.g., `ModbusDataService`, `MockDataService`)。
* `Views/`: UI 視窗與頁面 (e.g., `MainWindow`, `SettingsWin`, `SettingPage`)。
* `UserControls/`: 可重用的自訂控制項 (e.g., `MonitorUC`, `RingUC`)。

截圖
<img width="1200" height="748" alt="螢幕擷取畫面 2026-02-04 164333" src="https://github.com/user-attachments/assets/a657d383-b110-4c96-9b27-308359b5d18c" />

