using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

//SharpDX
using SharpDX.Windows;
using System.Drawing;
using SharpDX.DXGI;
using SharpDX.Direct2D1;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.Mathematics.Interop;
using SharpDX.WIC;
using SharpDX.IO;

using NAudio.Wave;

using D3D11 = SharpDX.Direct3D11;
using Device = SharpDX.Direct3D11.Device;
using D2DFactory = SharpDX.Direct2D1.Factory;
using DXGIFactory = SharpDX.DXGI.Factory;
using AlphaMode = SharpDX.Direct2D1.AlphaMode;
using System.Windows.Forms;
using Color = SharpDX.Color;
using NAudio.Wave.SampleProviders;

namespace GameEngine
{
    //A stripped version of the System.Windows.Forms.Keys enum to avoid extra includes for students.
    #region RawDataTypes

    public enum Key
    {
        //Modifiers = -65536,
        //None = 0,
        //LButton = 1,
        //RButton = 2,
        //Cancel = 3,
        //MButton = 4,
        //XButton1 = 5,
        //XButton2 = 6,
        Back = 8,
        Tab = 9,
        //LineFeed = 10,
        Clear = 12,
        Return = 13,
        Enter = 13,
        ShiftKey = 16,
        ControlKey = 17,
        Menu = 18,
        Pause = 19,
        //Capital = 20,
        CapsLock = 20,
        //KanaMode = 21,
        //HanguelMode = 21,
        //HangulMode = 21,
        //JunjaMode = 23,
        //FinalMode = 24,
        //HanjaMode = 25,
        //KanjiMode = 25,
        Escape = 27,
        //IMEConvert = 28,
        //IMENonconvert = 29,
        //IMEAccept = 30,
        //IMEAceept = 30,
        //IMEModeChange = 31,
        Space = 32,
        Prior = 33,
        PageUp = 33,
        Next = 34,
        PageDown = 34,
        End = 35,
        Home = 36,
        Left = 37,
        Up = 38,
        Right = 39,
        Down = 40,
        Select = 41,
        Print = 42,
        Execute = 43,
        Snapshot = 44,
        PrintScreen = 44,
        Insert = 45,
        Delete = 46,
        Help = 47,
        D0 = 48,
        D1 = 49,
        D2 = 50,
        D3 = 51,
        D4 = 52,
        D5 = 53,
        D6 = 54,
        D7 = 55,
        D8 = 56,
        D9 = 57,
        A = 65,
        B = 66,
        C = 67,
        D = 68,
        E = 69,
        F = 70,
        G = 71,
        H = 72,
        I = 73,
        J = 74,
        K = 75,
        L = 76,
        M = 77,
        N = 78,
        O = 79,
        P = 80,
        Q = 81,
        R = 82,
        S = 83,
        T = 84,
        U = 85,
        V = 86,
        W = 87,
        X = 88,
        Y = 89,
        Z = 90,
        LWin = 91,
        RWin = 92,
        //Apps = 93,
        Sleep = 95,
        NumPad0 = 96,
        NumPad1 = 97,
        NumPad2 = 98,
        NumPad3 = 99,
        NumPad4 = 100,
        NumPad5 = 101,
        NumPad6 = 102,
        NumPad7 = 103,
        NumPad8 = 104,
        NumPad9 = 105,
        Multiply = 106,
        Add = 107,
        Separator = 108,
        Subtract = 109,
        Decimal = 110,
        Divide = 111,
        F1 = 112,
        F2 = 113,
        F3 = 114,
        F4 = 115,
        F5 = 116,
        F6 = 117,
        F7 = 118,
        F8 = 119,
        F9 = 120,
        F10 = 121,
        F11 = 122,
        F12 = 123,
        F13 = 124,
        F14 = 125,
        F15 = 126,
        F16 = 127,
        F17 = 128,
        F18 = 129,
        F19 = 130,
        F20 = 131,
        F21 = 132,
        F22 = 133,
        F23 = 134,
        F24 = 135,
        NumLock = 144,
        Scroll = 145,
        LShiftKey = 160,
        RShiftKey = 161,
        LControlKey = 162,
        RControlKey = 163,
        //LMenu = 164,
        //RMenu = 165,
        //BrowserBack = 166,
        //BrowserForward = 167,
        //BrowserRefresh = 168,
        //BrowserStop = 169,
        //BrowserSearch = 170,
        //BrowserFavorites = 171,
        //BrowserHome = 172,
        //VolumeMute = 173,
        //VolumeDown = 174,
        //VolumeUp = 175,
        //MediaNextTrack = 176,
        //MediaPreviousTrack = 177,
        //MediaStop = 178,
        //MediaPlayPause = 179,
        //LaunchMail = 180,
        //SelectMedia = 181,
        //LaunchApplication1 = 182,
        //LaunchApplication2 = 183,
        //OemSemicolon = 186,
        //Oem1 = 186,
        //Oemplus = 187,
        //Oemcomma = 188,
        //OemMinus = 189,
        //OemPeriod = 190,
        //OemQuestion = 191,
        //Oem2 = 191,
        //Oemtilde = 192,
        //Oem3 = 192,
        //OemOpenBrackets = 219,
        //Oem4 = 219,
        //OemPipe = 220,
        //Oem5 = 220,
        //OemCloseBrackets = 221,
        //Oem6 = 221,
        //OemQuotes = 222,
        //Oem7 = 222,
        //Oem8 = 223,
        //OemBackslash = 226,
        //Oem102 = 226,
        //ProcessKey = 229,
        //Packet = 231,
        //Attn = 246,
        //Crsel = 247,
        //Exsel = 248,
        //EraseEof = 249,
        //Play = 250,
        //Zoom = 251,
        //NoName = 252,
        //Pa1 = 253,
        //OemClear = 254,
        //KeyCode = 65535,
        //Shift = 65536,
        //Control = 131072,
        //Alt = 262144
    }

    public class Color
    {
        public static Color White
        {
            get { return new Color(255, 255, 255); }
        }
        public static Color Black
        {
            get { return new Color(0, 0, 0); }
        }
        public static Color Red
        {
            get { return new Color(255, 0, 0); }
        }
        public static Color Green
        {
            get { return new Color(0, 255, 0); }
        }
        public static Color Blue
        {
            get { return new Color(0, 0, 255); }
        }
        public static Color Gray
        {
            get { return new Color(128, 128, 128); }
        }

        private int m_R;
        public int R
        {
            get { return m_R; }
            set { m_R = value; }
        }

        private int m_G;
        public int G
        {
            get { return m_G; }
            set { m_G = value; }
        }

        private int m_B;
        public int B
        {
            get { return m_B; }
            set { m_B = value; }
        }

        public Color(int r, int g, int b)
        {
            m_R = r;
            m_G = g;
            m_B = b;
        }
    }

    public struct Vector2
    {
        public static Vector2 zero
        {
            get { return new Vector2(0, 0); }
        }

        private int m_X;
        public int X
        {
            get { return m_X; }
            set { m_X = value; }
        }

        private int m_Y;
        public int Y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }

        public Vector2(int x, int y)
        {
            m_X = x;
            m_Y = y;
        }

        public static Vector2 operator +(Vector2 vec1, Vector2 vec2)
        {
            return new Vector2(vec1.X + vec2.X, vec1.Y + vec2.Y);
        }
    }

    public struct Vector2f
    {
        public static Vector2f zero
        {
            get { return new Vector2f(0.0f, 0.0f); }
        }

        private float m_X;
        public float X
        {
            get { return m_X; }
            set { m_X = value; }
        }

        private float m_Y;
        public float Y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }

        public Vector2f(float x, float y)
        {
            m_X = x;
            m_Y = y;
        }

        public static Vector2f operator +(Vector2f vec1, Vector2f vec2)
        {
            return new Vector2f(vec1.X + vec2.X, vec1.Y + vec2.Y);
        }
    }

    public struct Rectangle
    {
        private int m_X;
        public int X
        {
            get { return m_X; }
            set { m_X = value; }
        }

        private int m_Y;
        public int Y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }

        private int m_Width;
        public int Width
        {
            get { return m_Width; }
            set { m_Width = value; }
        }

        private int m_Height;
        public int Height
        {
            get { return m_Height; }
            set { m_Height = value; }
        }

        public Rectangle(int x, int y, int width, int height)
        {
            m_X = x;
            m_Y = y;
            m_Width = width;
            m_Height = height;
        }
    }

    #endregion

    public class GameEngine : IDisposable
    {
        //Singleton
        private static GameEngine m_Instance;

        //Subscribed game objects
        private List<GameObject> m_GameObjects;

        //DirectX
        private RenderForm m_RenderForm;
        private SwapChain m_SwapChain;
        private D2DFactory m_Factory;
        private RenderTarget m_RenderTarget;
        public RenderTarget RenderTarget
        {
            //Used a property on purpose as students don't need to use this. (only the Bitmap class does)
            get { return m_RenderTarget; }
        }

        //Subdevisions
        private InputManager m_InputManager;
        private AudioManager m_AudioManager;

        //Window properties
        private string m_Title = "Why did you remove the SetTitle line in AbstractGame?";
        private string m_IconPath = "../../Assets/icon.ico";
        private int m_Width = 800;
        private int m_Height = 600;
        private SharpDX.Color m_ClearColor = new SharpDX.Color(255, 255, 255);

        //Default properties
        private SolidColorBrush m_CurrentBrush;
        private Font m_DefaultFont; //So students can quickly get text on the screen without messing around with fonts.

        //For deltaTime calculation
        private Stopwatch m_Stopwatch;
        private float m_LastDeltaTime = 0.0f;

        //To force students to draw only in the paint function!
        private bool m_CanIPaint = false;

        //--------------------------
        // Functions
        //--------------------------

        //Core
        public GameEngine()
        {
            m_GameObjects = new List<GameObject>();
        }

        public void Dispose()
        {
            //This is the destructor
            for (int i = m_GameObjects.Count - 1; i >= 0; --i)
                m_GameObjects[i].GameEnd();

            m_GameObjects.Clear();

            m_RenderForm.Dispose();

            m_SwapChain.Dispose();
            m_RenderTarget.Dispose();

            m_Factory.Dispose();

            m_DefaultFont.Dispose();

            m_AudioManager.Dispose();
        }

        private void CreateWindow()
        {
            m_RenderForm = new RenderForm(m_Title);
            m_RenderForm.Icon = Icon.ExtractAssociatedIcon(m_IconPath);
            m_RenderForm.ClientSize = new Size(m_Width, m_Height);
            m_RenderForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            InitializeDeviceResources();

            //Initialize the external managers
            m_InputManager = new InputManager(m_RenderForm);
            m_AudioManager = new AudioManager(44100, 2);

            //Default the brush & font
            m_CurrentBrush = new SolidColorBrush(m_RenderTarget, SharpDX.Color.Black);
            m_DefaultFont = new Font("Arial", 12.0f);
        }

        private void InitializeDeviceResources()
        {
            //DXGI_MODE_DESC (width, height, refresh rate, color format)
            ModeDescription modeDesc = new ModeDescription(m_Width, m_Height, new Rational(60, 1), Format.R8G8B8A8_UNorm);

            //DXGI_SWAP_CHAIN_DESC
            SwapChainDescription swapChainDesc = new SwapChainDescription()
            {
                ModeDescription = modeDesc,
                SampleDescription = new SampleDescription(1, 0),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput,
                BufferCount = 1,
                OutputHandle = m_RenderForm.Handle,
                IsWindowed = true
            };

            //Create our device & swap chain
            Device device;
            Device.CreateWithSwapChain(DriverType.Hardware,
                                       DeviceCreationFlags.BgraSupport,
                                       new SharpDX.Direct3D.FeatureLevel[] { SharpDX.Direct3D.FeatureLevel.Level_10_0 },
                                       swapChainDesc,
                                       out device,
                                       out m_SwapChain);

            //We don't need this ref as we only use 2D
            device.Dispose();

            //Create backbuffer & rendertarget
            Texture2D backBuffer = Texture2D.FromSwapChain<Texture2D>(m_SwapChain, 0);
            Surface surface = backBuffer.QueryInterface<Surface>();
            backBuffer.Dispose();

            m_Factory = new D2DFactory();
            m_RenderTarget = new RenderTarget(m_Factory, surface, new RenderTargetProperties(new SharpDX.Direct2D1.PixelFormat(Format.Unknown, AlphaMode.Premultiplied)));

            // Disable automatic ALT+Enter processing because it doesn't work properly with WinForms
            DXGIFactory DXGIFactory = m_SwapChain.GetParent<DXGIFactory>();
            DXGIFactory.MakeWindowAssociation(m_RenderForm.Handle, WindowAssociationFlags.IgnoreAltEnter);
            DXGIFactory.Dispose();

            //And replace it with a custom bind
            m_RenderForm.KeyDown += (o, e) =>
            {
                if (e.Alt && e.KeyCode == Keys.Enter)
                    m_SwapChain.IsFullScreen = !m_SwapChain.IsFullScreen;
            };
        }

        public void Run()
        {
            if (m_GameObjects.Count == 0)
            {
                LogError("We are trying to run an undefined game!");
                return;
            }

            //Initialize the game
            foreach (GameObject go in m_GameObjects)
                go.GameInitialize();

            //Initialize the engine (window)
            CreateWindow();

            for (int i = m_GameObjects.Count - 1; i >= 0; --i)
                m_GameObjects[i].GameStart();

            //Start the core game / renderloop
            m_Stopwatch = new Stopwatch();
            m_Stopwatch.Start();

            RenderLoop.Run(m_RenderForm, () =>
            {
                m_RenderTarget.BeginDraw();
                m_RenderTarget.Clear(m_ClearColor); //Clearcolor

                //Update
                m_InputManager.Update();

                foreach (GameObject go in m_GameObjects)
                    go.Update();

                //Draw
                m_CanIPaint = true;

                foreach (GameObject go in m_GameObjects)
                    go.Paint();

                m_CanIPaint = false;

                m_RenderTarget.EndDraw();

                m_SwapChain.Present(1, PresentFlags.None); //1 for VSync

                m_LastDeltaTime = m_Stopwatch.ElapsedMilliseconds / 1000.0f;
                m_Stopwatch.Restart();
            });
        }

        private bool PaintCheck()
        {
            if (m_CanIPaint == false)
            {
                LogError("You are painting outside of the paint function!");
            }

            return m_CanIPaint;
        }

        public void SubscribeGameObject(GameObject go)
        {
            m_GameObjects.Add(go);
        }

        public void UnsubscribeGameObject(GameObject go)
        {
            m_GameObjects.Remove(go);
        }

        //Window mutators & accessors (we are not using C# properties to make everything more clear.)
        public static GameEngine GetInstance()
        {
            if (m_Instance == null) { m_Instance = new GameEngine(); }
                return m_Instance;
        }

        public float GetDeltaTime()
        {
            return m_LastDeltaTime;
        }

        public int GetScreenWidth()
        {
            return m_Width;
        }

        public int GetScreenHeight()
        {
            return m_Height;
        }

        public void SetTitle(string title)
        {
            m_Title = title;
        }

        public void SetIcon(string iconPath)
        {
            m_IconPath = iconPath;
        }

        public void SetWidth(int width)
        {
            if (width <= 0)
            {
                LogWarning("The screenwidth can not be smaller than 1 pixel. (SetWidth)");
                return;
            }

            m_Width = width;
        }

        public void SetHeight(int height)
        {
            if (height <= 0)
            {
                LogWarning("The screenheight can not be smaller than 1 pixel. (SetHeight)");
                return;
            }

            m_Height = height;
        }

        public void SetBackgroundColor(int r, int g, int b)
        {
            m_ClearColor = new SharpDX.Color(r, g, b);
        }

        public void SetBackgroundColor(Color color)
        {
            SetBackgroundColor(color.R, color.G, color.B);
        }

        //Draw methods
        public void SetColor(int r, int g, int b)
        {
            if (!PaintCheck())
                return;

            SharpDX.Color color = new SharpDX.Color(r, g, b);

            m_CurrentBrush.Dispose();
            m_CurrentBrush = new SolidColorBrush(m_RenderTarget, color);
        }

        public void SetColor(Color color)
        {
            SetColor(color.R, color.G, color.B);
        }

        //Line
        public void DrawLine(int startPointX, int startPointY, int endPointX, int endPointY)
        {
            if (!PaintCheck())
                return;

            RawVector2 p1 = new RawVector2((float)startPointX, (float)startPointY);
            RawVector2 p2 = new RawVector2((float)endPointX, (float)endPointY);

            m_RenderTarget.DrawLine(p1, p2, m_CurrentBrush);
        }

        public void DrawLine(Vector2 startPoint, Vector2 endPoint)
        {
            DrawLine(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
        }

        //Rectangle
        public void DrawRectangle(int x, int y, int width, int height)
        {
            //Not using default parameters on purpose.
            DrawRectangle(x, y, width, height, 1);
        }

        public void DrawRectangle(Rectangle rect)
        {
            DrawRectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }

        public void DrawRectangle(int x, int y, int width, int height, int strokeWidth)
        {
            if (!PaintCheck())
                return;

            RawRectangleF rect = new RawRectangleF((float)x, (float)y, (float)(x + width), (float)(y + height));
            m_RenderTarget.DrawRectangle(rect, m_CurrentBrush, (float)strokeWidth);
        }

        public void DrawRectangle(Rectangle rect, int strokeWidth)
        {
            DrawRectangle(rect.X, rect.Y, rect.Width, rect.Height, strokeWidth);
        }

        public void FillRectangle(int x, int y, int width, int height)
        {
            if (!PaintCheck())
                return;

            RawRectangleF rect = new RawRectangleF((float)x, (float)y, (float)(x + width), (float)(y + height));
            m_RenderTarget.FillRectangle(rect, m_CurrentBrush);
        }

        public void FillRectangle(Rectangle rect)
        {
            FillRectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }

        //Rounded rectangle
        public void DrawRoundedRectangle(int x, int y, int width, int height, int radiusX, int radiusY)
        {
            DrawRoundedRectangle(x, y, width, height, radiusX, radiusY, 1);
        }

        public void DrawRoundedRectangle(Rectangle rect, Vector2 radius)
        {
            DrawRoundedRectangle(rect.X, rect.Y, rect.Width, rect.Height, radius.X, radius.Y);
        }

        public void DrawRoundedRectangle(int x, int y, int width, int height, int radiusX, int radiusY, int strokeWidth)
        {
            if (!PaintCheck())
                return;

            RawRectangleF rect = new RawRectangleF((float)x, (float)y, (float)(x + width), (float)(y + height));

            RoundedRectangle roundedRect = new RoundedRectangle();
            roundedRect.Rect = rect;
            roundedRect.RadiusX = (float)radiusX;
            roundedRect.RadiusY = (float)radiusY;

            m_RenderTarget.DrawRoundedRectangle(roundedRect, m_CurrentBrush, strokeWidth);
        }

        public void DrawRoundedRectangle(Rectangle rect, Vector2 radius, int strokeWidth)
        {
            DrawRoundedRectangle(rect.X, rect.Y, rect.Width, rect.Height, radius.X, radius.Y, strokeWidth);
        }

        public void FillRoundedRectangle(int x, int y, int width, int height, int radiusX, int radiusY)
        {
            if (!PaintCheck())
                return;

            RawRectangleF rect = new RawRectangleF((float)x, (float)y, (float)(x + width), (float)(y + height));

            RoundedRectangle roundedRect = new RoundedRectangle();
            roundedRect.Rect = rect;
            roundedRect.RadiusX = (float)radiusX;
            roundedRect.RadiusY = (float)radiusY;

            m_RenderTarget.FillRoundedRectangle(ref roundedRect, m_CurrentBrush);
        }

        public void FillRoundedRectangle(Rectangle rect, Vector2 radius)
        {
            FillRoundedRectangle(rect.X, rect.Y, rect.Width, rect.Height, radius.X, radius.Y);
        }

        //Ellipse
        public void DrawEllipse(int x, int y, int width, int height)
        {
            //Not using default parameters on purpose.
            DrawEllipse(x, y, width, height, 1);
        }

        public void DrawEllipse(Rectangle rect)
        {
            DrawEllipse(rect.X, rect.Y, rect.Width, rect.Height);
        }

        public void DrawEllipse(int x, int y, int width, int height, int strokeWidth)
        {
            if (!PaintCheck())
                return;

            Ellipse ellipse = new Ellipse(new RawVector2((float)x, (float)y), (float)width, (float)height);
            m_RenderTarget.DrawEllipse(ellipse, m_CurrentBrush, (float)strokeWidth);
        }

        public void DrawEllipse(Rectangle rect, int strokeWidth)
        {
            DrawEllipse(rect.X, rect.Y, rect.Width, rect.Height, strokeWidth);
        }

        public void FillEllipse(int x, int y, int width, int height)
        {
            if (!PaintCheck())
                return;

            Ellipse ellipse = new Ellipse(new RawVector2((float)x, (float)y), (float)width, (float)height);
            m_RenderTarget.FillEllipse(ellipse, m_CurrentBrush);
        }

        public void FillEllipse(Rectangle rect)
        {
            FillEllipse(rect.X, rect.Y, rect.Width, rect.Height);
        }

        //Bitmaps
        public void DrawBitmap(Bitmap bitmap, int x, int y)
        {
            DrawBitmap(bitmap, x, y, 0, 0, 0, 0);
        }

        public void DrawBitmap(Bitmap bitmap, Vector2 position)
        {
            DrawBitmap(bitmap, position.X, position.Y);

        }

        public void DrawBitmap(Bitmap bitmap, int x, int y, int sourceX, int sourceY, int sourceWidth, int sourceHeight)
        {
            if (!PaintCheck())
                return;

            SharpDX.Direct2D1.Bitmap D2DBitmap = bitmap.D2DBitmap;

            if (sourceWidth == 0)  sourceWidth = (int)D2DBitmap.Size.Width;
            if (sourceHeight == 0) sourceHeight = (int)D2DBitmap.Size.Height;

            RawRectangleF sourceRect = new RawRectangleF((float)sourceX, (float)sourceY, (float)(sourceX + sourceWidth), (float)(sourceY + sourceHeight));

            m_RenderTarget.Transform = SharpDX.Matrix3x2.Translation(x, y);
            m_RenderTarget.DrawBitmap(D2DBitmap, 1.0f, SharpDX.Direct2D1.BitmapInterpolationMode.NearestNeighbor, sourceRect);
            m_RenderTarget.Transform = SharpDX.Matrix3x2.Translation(0, 0);
        }

        public void DrawBitmap(Bitmap bitmap, int x, int y, Rectangle sourceRect)
        {
            DrawBitmap(bitmap, x, y, sourceRect.X, sourceRect.Y, sourceRect.Width, sourceRect.Height);
        }

        public void DrawBitmap(Bitmap bitmap, Vector2 position, Rectangle sourceRect)
        {
            DrawBitmap(bitmap, position.X, position.Y, sourceRect.X, sourceRect.Y, sourceRect.Width, sourceRect.Height);
        }

        //Text
        public void DrawString(string text, int x, int y, int width, int height)
        {
            DrawString(null, text, x, y, width, height);
        }

        public void DrawString(string text, Rectangle rect)
        {
            DrawString(text, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public void DrawString(Font font, string text, int x, int y, int width, int height)
        {
            if (!PaintCheck())
                return;

            if (font == null)
                font = m_DefaultFont;

            RawRectangleF rect = new RawRectangleF((float)x, (float)y, (float)(x + width), (float)(y + height));
            m_RenderTarget.DrawText(text, font.TextFormat, rect, m_CurrentBrush);
        }

        public void DrawString(Font font, string text, Rectangle rect)
        {
            DrawString(font, text, rect.X, rect.Y, rect.Width, rect.Height);
        }

        //Input methods
        public bool GetKey(Key key)
        {
            return m_InputManager.GetKey(key);
        }

        public bool GetKeyDown(Key key)
        {
            return m_InputManager.GetKeyDown(key);
        }

        public bool GetKeyUp(Key key)
        {
            return m_InputManager.GetKeyUp(key);
        }

        public bool GetMouseButton(int buttonID)
        {
            return m_InputManager.GetMouseButton(buttonID);
        }

        public bool GetMouseButtonDown(int buttonID)
        {
            return m_InputManager.GetMouseButtonDown(buttonID);
        }

        public bool GetMouseButtonUp(int buttonID)
        {
            return m_InputManager.GetMouseButtonUp(buttonID);
        }

        public Vector2 GetMousePosition()
        {
            return m_InputManager.GetMousePosition();
        }

        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("DEBUG: " + message);
        }

        public void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("WARNING: " + message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: " + message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Audio methods
        public void PlayAudio(Audio audio)
        {
            m_AudioManager.PlayAudio(audio);
        }

        public void StopAudio(Audio audio)
        {
            m_AudioManager.StopAudio(audio);
        }

        public void SetVolume(float volume)
        {
            if (volume < 0.0f)
            {
                LogError("The volume cannot be lower than 0.0");
                return;
            }

            if (volume > 1.0f)
            {
                LogError("The volume cannot be higher than 1.0");
                return;
            }

            m_AudioManager.SetVolume(volume);
        }

        //Camera methods TODO

        private class InputManager
        {
            //Input snapshot of this frame
            private List<Keys> m_KeysPressed;
            private List<Keys> m_KeysDown;
            private List<Keys> m_KeysUp;

            private List<MouseButtons> m_MouseButtonsPressed;
            private List<MouseButtons> m_MouseButtonsDown;
            private List<MouseButtons> m_MouseButtonsUp;

            //Used to accuratly fill the arrays above
            private List<Keys> m_KeysDownLastFrame;
            private List<Keys> m_KeysUpLastFrame;
            private List<MouseButtons> m_MouseButtonsDownLastFrame;
            private List<MouseButtons> m_MouseButtonsUpLastFrame;

            private Vector2 m_MousePosition;

            public InputManager(RenderForm renderForm)
            {
                //Initialize the arrays
                m_KeysPressed = new List<Keys>();
                m_KeysDown = new List<Keys>();
                m_KeysUp = new List<Keys>();

                m_MouseButtonsPressed = new List<MouseButtons>();
                m_MouseButtonsDown = new List<MouseButtons>();
                m_MouseButtonsUp = new List<MouseButtons>();

                m_KeysDownLastFrame = new List<Keys>();
                m_KeysUpLastFrame = new List<Keys>();
                m_MouseButtonsDownLastFrame = new List<MouseButtons>();
                m_MouseButtonsUpLastFrame = new List<MouseButtons>();

                m_MousePosition = new Vector2(0, 0);

                StartListening(renderForm);
            }

            private void StartListening(RenderForm renderForm)
            {
                //Because this doesn't go in sync with our own Update loop we manage "Down & Up" ourselves.

                //Keys
                renderForm.KeyDown += (o, e) =>
                {
                    m_KeysDownLastFrame.Add(e.KeyCode);
                };

                renderForm.KeyUp += (o, e) =>
                {
                    m_KeysUpLastFrame.Add(e.KeyCode);
                };

                //Mouse
                renderForm.MouseDown += (o, e) =>
                {
                    m_MouseButtonsDownLastFrame.Add(e.Button);
                };

                renderForm.MouseUp += (o, e) =>
                {
                    m_MouseButtonsUpLastFrame.Add(e.Button);
                };

                renderForm.MouseMove += (o, e) =>
                {
                    m_MousePosition.X = e.X;
                    m_MousePosition.Y = e.Y;
                };
            }

            public void Update()
            {
                HandleKeyboardInput();
                HandleMouseInput();
            }

            private void HandleKeyboardInput()
            {
                m_KeysDown.Clear();
                m_KeysUp.Clear();

                foreach (Keys key in m_KeysDownLastFrame)
                {
                    if (m_KeysPressed.Contains(key) == false)
                    {
                        m_KeysDown.Add(key);
                        m_KeysPressed.Add(key);
                    }
                }

                foreach (Keys key in m_KeysUpLastFrame)
                {
                    if (m_KeysPressed.Contains(key) == true)
                    {
                        m_KeysUp.Add(key);
                        m_KeysPressed.Remove(key);
                    }
                }

                m_KeysDownLastFrame.Clear();
                m_KeysUpLastFrame.Clear();
            }

            private void HandleMouseInput()
            {
                m_MouseButtonsDown.Clear();
                m_MouseButtonsUp.Clear();

                foreach (MouseButtons button in m_MouseButtonsDownLastFrame)
                {
                    if (m_MouseButtonsPressed.Contains(button) == false)
                    {
                        m_MouseButtonsDown.Add(button);
                        m_MouseButtonsPressed.Add(button);
                    }
                }

                foreach (MouseButtons button in m_MouseButtonsUpLastFrame)
                {
                    if (m_MouseButtonsPressed.Contains(button) == true)
                    {
                        m_MouseButtonsUp.Add(button);
                        m_MouseButtonsPressed.Remove(button);
                    }
                }

                m_MouseButtonsDownLastFrame.Clear();
                m_MouseButtonsUpLastFrame.Clear();
            }

            //Functions mimic the way it works in Unity.
            public bool GetKey(Key key)
            {
                return m_KeysPressed.Contains((Keys)key);
            }

            public bool GetKeyDown(Key key)
            {
                return m_KeysDown.Contains((Keys)key);
            }

            public bool GetKeyUp(Key key)
            {
                return m_KeysUp.Contains((Keys)key);
            }

            public bool GetMouseButton(int buttonID)
            {
                MouseButtons button = TranslateMouseButton(buttonID);
                return m_MouseButtonsPressed.Contains(button);
            }

            public bool GetMouseButtonDown(int buttonID)
            {
                MouseButtons button = TranslateMouseButton(buttonID);
                return m_MouseButtonsDown.Contains(button);
            }

            public bool GetMouseButtonUp(int buttonID)
            {
                MouseButtons button = TranslateMouseButton(buttonID);
                return m_MouseButtonsUp.Contains(button);
            }

            public Vector2 GetMousePosition()
            {
                return m_MousePosition;
            }

            private MouseButtons TranslateMouseButton(int buttonID)
            {
                switch (buttonID)
                {
                    case 0: return MouseButtons.Left;
                    case 1: return MouseButtons.Right;
                    case 2: return MouseButtons.Middle;

                    default: return MouseButtons.None;
                }
            }
        }

        private class AudioManager
        {
            private WaveOut m_OutputDevice;
            private MixingSampleProvider m_Mixer;

            public AudioManager(int sampleRate, int channelCount)
            {
                m_OutputDevice = new WaveOut();

                m_Mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount));
                m_Mixer.ReadFully = true;
                m_Mixer.RemoveAllMixerInputs();

                m_OutputDevice.Init(m_Mixer);
                m_OutputDevice.Play();
            }

            public void Dispose()
            {
                m_OutputDevice.Stop();
                m_OutputDevice.Dispose();
            }

            public void PlayAudio(Audio audio)
            {
                m_Mixer.AddMixerInput(ConvertToRightChannelCount(audio));
            }

            public void StopAudio(Audio audio)
            {
                m_Mixer.RemoveMixerInput(ConvertToRightChannelCount(audio));
            }

            public void SetVolume(float volume)
            {
                m_OutputDevice.Volume = volume;
            }

            private ISampleProvider ConvertToRightChannelCount(ISampleProvider input)
            {
                if (input.WaveFormat.Channels == m_Mixer.WaveFormat.Channels)
                {
                    return input;
                }

                if (input.WaveFormat.Channels == 1 && m_Mixer.WaveFormat.Channels == 2)
                {
                    return new MonoToStereoSampleProvider(input);
                }

                GameEngine.GetInstance().LogError("No such channel conversion currently exists.");
                return input;
            }
        }
    }

    #region DataTypes

    public class GameObject
    {
        private GameEngine m_GameEngine;
        protected GameEngine GAME_ENGINE
        {
            get { return m_GameEngine; }
        }

        public GameObject()
        {
            m_GameEngine = GameEngine.GetInstance();
            m_GameEngine.SubscribeGameObject(this);
        }

        public virtual void GameInitialize() { }
        public virtual void GameStart() { }
        public virtual void GameEnd()
        {
            m_GameEngine.UnsubscribeGameObject(this);
        }
        public virtual void Update() { }
        public virtual void Paint() { }
    }

    public class Bitmap : IDisposable
    {
        private SharpDX.Direct2D1.Bitmap m_D2DBitmap;
        public SharpDX.Direct2D1.Bitmap D2DBitmap
        {
            get { return m_D2DBitmap; }
        }

        public Bitmap(string filePath)
        {
            LoadBitmap("../../Assets/" + filePath);
        }

        public void Dispose()
        {
            //This is the destructor
            m_D2DBitmap.Dispose();
        }

        private void LoadBitmap(string filePath)
        {
            //Read the image
            ImagingFactory imagingFactory = new ImagingFactory();
            NativeFileStream fileStream = new NativeFileStream(filePath, NativeFileMode.Open, NativeFileAccess.Read);

            //Decode and get the frame (decodes all sorts of image formats for us)
            BitmapDecoder bitmapDecoder = new BitmapDecoder(imagingFactory, fileStream, DecodeOptions.CacheOnDemand);
            BitmapFrameDecode frame = bitmapDecoder.GetFrame(0);

            //Convert the colors to the Direct2D standard
            FormatConverter converter = new FormatConverter(imagingFactory);
            converter.Initialize(frame, SharpDX.WIC.PixelFormat.Format32bppPRGBA);

            RenderTarget renderTarget = GameEngine.GetInstance().RenderTarget;
            m_D2DBitmap = SharpDX.Direct2D1.Bitmap1.FromWicBitmap(renderTarget, converter);
        }

        private void SetTransparancyColor(Color color)
        {
            //To be made, for now use PNG
            //new SharpDX.Direct2D1.Effects.ColorManagement()
        }

        public int GetWidth()
        {
            return (int)m_D2DBitmap.Size.Width;
        }

        public int GetHeight()
        {
            return (int)m_D2DBitmap.Size.Height;
        }
    }

    public class Font : IDisposable
    {
        public enum Alignment
        {
            Left,
            Right,
            Center
        }

        private SharpDX.DirectWrite.TextFormat m_TextFormat;
        public SharpDX.DirectWrite.TextFormat TextFormat
        {
            get { return m_TextFormat; }
        }

        public Font(string fontName, float size)
        {
            CreateFont(fontName, size);
        }

        public void Dispose()
        {
            //This is the destructor
            m_TextFormat.Dispose();
        }

        private void CreateFont(string fontName, float size)
        {
            SharpDX.DirectWrite.Factory fontFactory = new SharpDX.DirectWrite.Factory();
            m_TextFormat = new SharpDX.DirectWrite.TextFormat(fontFactory, fontName, size);
            fontFactory.Dispose();
        }
        
        public void SetHorizontalAlignment(Alignment alignment)
        {
            m_TextFormat.TextAlignment = (SharpDX.DirectWrite.TextAlignment)alignment;
        }

        public void SetVerticalAlignment(Alignment alignment)
        {
            m_TextFormat.ParagraphAlignment = (SharpDX.DirectWrite.ParagraphAlignment)alignment;
        }
    }

    public class Button : GameObject
    {
        public delegate void ButtonCallback();

        //State
        private Font m_DefaultFont;
        private Font m_Font;
        private Bitmap m_Bitmap; //Instead of colors we can also use a bitmap as the background

        private bool m_IsHovering;
        private bool m_IsClicked;

        //Required
        private string m_Text = "Button";
        private Rectangle m_Rectangle = new Rectangle(0, 0, 100, 25);
        private ButtonCallback m_Callback;

        //Extra settings
        private Color m_ForegroundColor = Color.Black;
        private Color m_BackgroundColor = Color.White;
        private Color m_BorderColor = Color.Black;

        private Color m_HoverForegroundColor = Color.Black;
        private Color m_HoverBackgroundColor = new Color(245, 245, 245);
        private Color m_HoverBorderColor = Color.Black;

        private Color m_ClickForegroundColor = Color.Black;
        private Color m_ClickBackgroundColor = new Color(200, 200, 200);
        private Color m_ClickBorderColor = Color.Black;

        private Vector2 m_CornerRadius = new Vector2(0, 0);


        //Functions
        public Button(ButtonCallback callback) : base()
        {
            Initialize(callback, "Button", new Rectangle(0, 0, 100, 25));
        }

        public Button(ButtonCallback callback, string text, int x, int y, int width, int height) : base()
        {
            Initialize(callback, text, new Rectangle(x, y, width, height));
        }

        public Button(ButtonCallback callback, string text, Rectangle rectangle) : base()
        {
            Initialize(callback, text, rectangle);
        }

        private void Initialize(ButtonCallback callback, string text, Rectangle rectangle)
        {
            m_Text = text;
            m_Rectangle = rectangle;
            m_Callback = callback;

            m_DefaultFont = new Font("Arial", 12.0f);
            m_DefaultFont.SetHorizontalAlignment(Font.Alignment.Center);
            m_DefaultFont.SetVerticalAlignment(Font.Alignment.Center);

            m_Font = m_DefaultFont;
        }

        public override void GameEnd()
        {
            m_DefaultFont.Dispose();

            if (m_Bitmap != null)
                m_Bitmap.Dispose();

            GAME_ENGINE.UnsubscribeGameObject(this);
        }

        public override void Update()
        {
            //Check if the mouse position is colliding with our button
            Vector2 mousePosition = GAME_ENGINE.GetMousePosition();

            m_IsClicked = false;
            m_IsHovering = (!(mousePosition.X < m_Rectangle.X ||
                              mousePosition.X > (m_Rectangle.X + m_Rectangle.Width) ||
                              mousePosition.Y < m_Rectangle.Y ||
                              mousePosition.Y > (m_Rectangle.Y + m_Rectangle.Height)));

            if (m_IsHovering)
            {
                m_IsClicked = GAME_ENGINE.GetMouseButton(0);

                if (GAME_ENGINE.GetMouseButtonUp(0))
                {
                    if (m_Callback != null)
                        m_Callback();
                }
            }
        }

        public override void Paint()
        {
            Color fgColor = m_ForegroundColor;
            Color bgColor = m_BackgroundColor;
            Color borderColor = m_BorderColor;

            if (m_IsHovering)
            {
                fgColor = m_HoverForegroundColor;
                bgColor = m_HoverBackgroundColor;
                borderColor = m_HoverBorderColor;
            }

            if (m_IsClicked)
            {
                fgColor = m_ClickForegroundColor;
                bgColor = m_ClickBackgroundColor;
                borderColor = m_ClickBorderColor;
            }

            if (m_Bitmap != null)
            {
                DrawBitmapButton();
            }
            else
            {
                if (m_CornerRadius.X == 0 && m_CornerRadius.Y == 0)
                    DrawRectangleButton(bgColor, borderColor);
                else
                    DrawRoundedRectangleButton(bgColor, borderColor);
            }

            //Text
            GAME_ENGINE.SetColor(fgColor);
            GAME_ENGINE.DrawString(m_Font, m_Text, m_Rectangle);
        }

        private void DrawRectangleButton(Color backgroundColor, Color borderColor)
        {
            //Background
            GAME_ENGINE.SetColor(backgroundColor);
            GAME_ENGINE.FillRectangle(m_Rectangle);

            //Border
            GAME_ENGINE.SetColor(borderColor);
            GAME_ENGINE.DrawRectangle(m_Rectangle);
        }

        private void DrawRoundedRectangleButton(Color backgroundColor, Color borderColor)
        {
            //Background
            GAME_ENGINE.SetColor(backgroundColor);
            GAME_ENGINE.FillRoundedRectangle(m_Rectangle, m_CornerRadius);

            //Border
            GAME_ENGINE.SetColor(borderColor);
            GAME_ENGINE.DrawRoundedRectangle(m_Rectangle, m_CornerRadius);
        }

        private void DrawBitmapButton()
        {
            int yOffset = 0;
            if (m_IsHovering) yOffset += m_Rectangle.Height;
            if (m_IsClicked)  yOffset += m_Rectangle.Height;

            GAME_ENGINE.DrawBitmap(m_Bitmap, m_Rectangle.X, m_Rectangle.Y, 0, yOffset, m_Rectangle.Width, m_Rectangle.Height);
        }


        //Mutators & Accessors
        public void SetCallback(ButtonCallback callback)
        {
            m_Callback = callback;
        }

        public void SetText(string text)
        {
            m_Text = text;
        }

        public void SetPosition(int x, int y)
        {
            m_Rectangle = new Rectangle(x, y, m_Rectangle.Width, m_Rectangle.Height);
        }

        public void SetSize(int width, int height)
        {
            m_Rectangle = new Rectangle(m_Rectangle.X, m_Rectangle.Y, width, height);
        }

        public void SetRectangle(int x, int y, int width, int height)
        {
            m_Rectangle = new Rectangle(x, y, width, height);
        }

        public void SetRectangle(Rectangle rectangle)
        {
            m_Rectangle = rectangle;
        }


        public void SetForegroundColor(Color color)
        {
            m_ForegroundColor = color;
        }

        public void SetBackgroundColor(Color color)
        {
            m_BackgroundColor = color;
        }

        public void SetBorderColor(Color color)
        {
            m_BorderColor = color;
        }

        public void SetHoverForegroundColor(Color color)
        {
            m_HoverForegroundColor = color;
        }

        public void SetHoverBackgroundColor(Color color)
        {
            m_HoverBackgroundColor = color;
        }

        public void SetHoverBorderColor(Color color)
        {
            m_HoverBorderColor = color;
        }

        public void SetClickForegroundColor(Color color)
        {
            m_ClickForegroundColor = color;
        }

        public void SetClickBackgroundColor(Color color)
        {
            m_ClickBackgroundColor = color;
        }

        public void SetClickBorderColor(Color color)
        {
            m_ClickBorderColor = color;
        }


        public void SetBitmap(string filepath)
        {
            m_Bitmap = new Bitmap(filepath);
        }

        public void SetBitmap(Bitmap bitmap)
        {
            m_Bitmap = bitmap;
        }

        public void SetFont(Font font)
        {
            m_Font = font;
        }

        public void SetCornerRadius(Vector2 radius)
        {
            m_CornerRadius = radius;
        }
    }

    public class Audio : IDisposable, ISampleProvider
    {
        private float[] m_OriginalData;
        private float[] m_Data;
        private long m_CurrentPosition;

        private float m_Volume = 1.0f;
        private bool m_IsLooping = false;

        private WaveFormat m_WaveFormat;
        public WaveFormat WaveFormat
        {
            get { return m_WaveFormat; }
        }

        public Audio(string filePath)
        {
            LoadAudio("../../Assets/" + filePath);
        }

        private void LoadAudio(string filePath)
        {
            using (AudioFileReader audioFileReader = new AudioFileReader(filePath))
            {
                //Make sure all audio uses the same samplerate
                WaveToSampleProvider convStream = new WaveToSampleProvider(new MediaFoundationResampler(new SampleToWaveProvider(audioFileReader),
                                                                                                        WaveFormat.CreateIeeeFloatWaveFormat(44100, 2)) { ResamplerQuality = 60 });

                
                m_WaveFormat = convStream.WaveFormat;

                List<float> wholeFile = new List<float>((int)(audioFileReader.Length / 4));
                float[] readBuffer = new float[convStream.WaveFormat.SampleRate * convStream.WaveFormat.Channels];

                int samplesRead;
                while ((samplesRead = convStream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                {
                    wholeFile.AddRange(readBuffer.Take(samplesRead));
                }

                m_OriginalData = wholeFile.ToArray();
                m_Data = m_OriginalData;
            }
        }

        public void Dispose()
        {

        }

        public void SetVolume(float volume)
        {
            //We'll just do this manually otherwise finding a way out of all these conversion classes (see LoadAudio) will be a nightmare.
            //As long as we don't use this to fadeout we'll be fine.
            for (int i = 0; i < m_OriginalData.Length; ++i)
            {
                m_Data[i] = m_OriginalData[i] * volume;
            }
        }

        public void SetLooping(bool looping)
        {
            m_IsLooping = looping;
        }

        public float GetVolume()
        {
            return m_Volume;
        }

        public bool IsLooping()
        {
            return m_IsLooping;
        }

        //ISampleProvider
        public int Read(float[] buffer, int offset, int count)
        {
            long availableSamples = m_Data.Length - m_CurrentPosition;

            //Looping
            if (availableSamples <= 0 && m_IsLooping == true)
            {
                m_CurrentPosition = 0;
                availableSamples = m_Data.Length - m_CurrentPosition;
            }

            long samplesToCopy = Math.Min(availableSamples, count);

            Array.Copy(m_Data, m_CurrentPosition, buffer, offset, samplesToCopy);

            m_CurrentPosition += samplesToCopy;

            return (int)samplesToCopy;
        }
    }

    #endregion
}
