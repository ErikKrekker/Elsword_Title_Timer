namespace _Elsword__Title_Timer {
    class Program {
        static async Task Main() {
            using var overlay = new TimerOverlay();
            await overlay.Run();
        }
    }
}