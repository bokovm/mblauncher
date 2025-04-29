using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyWpfApp.ViewModels
{
    /// <summary>
    /// Базовый класс для ViewModel, реализующий INotifyPropertyChanged.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызывает событие PropertyChanged для уведомления об изменении свойства.
        /// </summary>
        /// <param name="propertyName">Имя изменённого свойства (определяется автоматически).</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Устанавливает значение свойства и вызывает событие PropertyChanged, если значение изменилось.
        /// </summary>
        /// <typeparam name="T">Тип свойства.</typeparam>
        /// <param name="field">Ссылка на поле, связанное с этим свойством.</param>
        /// <param name="value">Новое значение.</param>
        /// <param name="propertyName">Имя свойства (определяется автоматически).</param>
        /// <returns>Возвращает true, если значение было изменено, иначе false.</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}