using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Helpers;

namespace BattleChess3.UI.Utilities
{
  public class RedirectCommand : ICommand
  {
    public event EventHandler? Handler;
    
    private readonly WeakAction? _execute;
    private readonly WeakFunc<bool>? _canExecute;

    /// <summary>
    ///     Occurs when changes occur that affect whether the command should execute.
    /// </summary>
    public event EventHandler? CanExecuteChanged;

    /// <summary>
    ///     Initializes a new instance of the RelayCommand class that
    ///     can always execute.
    /// </summary>
    /// <param name="keepTargetAlive">
    ///     If true, the target of the Action will
    ///     be kept as a hard reference, which might cause a memory leak. You should only set this
    ///     parameter to true if the action is causing a closure. See
    ///     http://galasoft.ch/s/mvvmweakaction.
    /// </param>
    /// <exception cref="T:System.ArgumentNullException">If the execute argument is null.</exception>
    public RedirectCommand(bool keepTargetAlive = false)
      : this(null, keepTargetAlive)
    {
    }

    /// <summary>Initializes a new instance of the RelayCommand class.</summary>
    /// <param name="execute">
    ///     The execution logic. IMPORTANT: If the action causes a closure,
    ///     you must set keepTargetAlive to true to avoid side effects.
    /// </param>
    /// <param name="canExecute">
    ///     The execution status logic.  IMPORTANT: If the func causes a closure,
    ///     you must set keepTargetAlive to true to avoid side effects.
    /// </param>
    /// <param name="keepTargetAlive">
    ///     If true, the target of the Action will
    ///     be kept as a hard reference, which might cause a memory leak. You should only set this
    ///     parameter to true if the action is causing a closures. See
    ///     http://galasoft.ch/s/mvvmweakaction.
    /// </param>
    /// <exception cref="T:System.ArgumentNullException">If the execute argument is null.</exception>
    public RedirectCommand(Func<bool>? canExecute, bool keepTargetAlive = false)
    {
      _execute = new WeakAction(() => Handler?.Invoke(this, EventArgs.Empty), keepTargetAlive);
      if (canExecute == null) return;
      _canExecute = new WeakFunc<bool>(canExecute, keepTargetAlive);
    }

    /// <summary>
    ///     Raises the <see cref="E:GalaSoft.MvvmLight.Command.RelayCommand.CanExecuteChanged" /> event.
    /// </summary>
    public void RaiseCanExecuteChanged()
      => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    /// <summary>
    ///     Defines the method that determines whether the command can execute in its current state.
    /// </summary>
    /// <param name="parameter">This parameter will always be ignored.</param>
    /// <returns>true if this command can be executed; otherwise, false.</returns>
    public bool CanExecute(object? parameter)
      => _canExecute == null || (_canExecute.IsStatic || _canExecute.IsAlive) && _canExecute.Execute();

    /// <summary>
    ///     Defines the method to be called when the command is invoked.
    /// </summary>
    /// <param name="parameter">This parameter will always be ignored.</param>
    public virtual void Execute(object? parameter = null)
    {
      if (!CanExecute(parameter) || _execute == null || !_execute.IsStatic && !_execute.IsAlive)
        return;
      _execute.Execute();
    }
  }
  
  public class RedirectCommand<T> : ICommand
  {
    public event EventHandler<T>? Handler;
    
    private readonly WeakAction<T>? _execute;
    private readonly WeakFunc<bool>? _canExecute;

    /// <summary>
    ///     Occurs when changes occur that affect whether the command should execute.
    /// </summary>
    public event EventHandler? CanExecuteChanged;

    /// <summary>
    ///     Initializes a new instance of the RelayCommand class that
    ///     can always execute.
    /// </summary>
    /// <param name="keepTargetAlive">
    ///     If true, the target of the Action will
    ///     be kept as a hard reference, which might cause a memory leak. You should only set this
    ///     parameter to true if the action is causing a closure. See
    ///     http://galasoft.ch/s/mvvmweakaction.
    /// </param>
    /// <exception cref="T:System.ArgumentNullException">If the execute argument is null.</exception>
    public RedirectCommand(bool keepTargetAlive = false)
      : this(null, keepTargetAlive)
    {
    }

    /// <summary>Initializes a new instance of the RelayCommand class.</summary>
    /// <param name="execute">
    ///     The execution logic. IMPORTANT: If the action causes a closure,
    ///     you must set keepTargetAlive to true to avoid side effects.
    /// </param>
    /// <param name="canExecute">
    ///     The execution status logic.  IMPORTANT: If the func causes a closure,
    ///     you must set keepTargetAlive to true to avoid side effects.
    /// </param>
    /// <param name="keepTargetAlive">
    ///     If true, the target of the Action will
    ///     be kept as a hard reference, which might cause a memory leak. You should only set this
    ///     parameter to true if the action is causing a closures. See
    ///     http://galasoft.ch/s/mvvmweakaction.
    /// </param>
    /// <exception cref="T:System.ArgumentNullException">If the execute argument is null.</exception>
    public RedirectCommand(Func<bool>? canExecute, bool keepTargetAlive = false)
    {
      _execute = new WeakAction<T>(x => Handler?.Invoke(this, x), keepTargetAlive);
      if (canExecute == null) return;
      _canExecute = new WeakFunc<bool>(canExecute, keepTargetAlive);
    }

    /// <summary>
    ///     Raises the <see cref="E:GalaSoft.MvvmLight.Command.RelayCommand.CanExecuteChanged" /> event.
    /// </summary>
    public void RaiseCanExecuteChanged()
      => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    /// <summary>
    ///     Defines the method that determines whether the command can execute in its current state.
    /// </summary>
    /// <param name="parameter">This parameter will always be ignored.</param>
    /// <returns>true if this command can be executed; otherwise, false.</returns>
    public bool CanExecute(T parameter)
      => _canExecute == null || (_canExecute.IsStatic || _canExecute.IsAlive) && _canExecute.Execute();

    /// <summary>
    ///     Defines the method that determines whether the command can execute in its current state.
    /// </summary>
    /// <param name="parameter">This parameter will always be ignored.</param>
    /// <returns>true if this command can be executed; otherwise, false.</returns>
    public bool CanExecute(object parameter)
      => _canExecute == null || (_canExecute.IsStatic || _canExecute.IsAlive) && _canExecute.Execute();

    /// <summary>
    ///     Defines the method to be called when the command is invoked.
    /// </summary>
    /// <param name="parameter">This parameter will always be ignored.</param>
    public virtual void Execute(object parameter)
    {
      if (!CanExecute(parameter) || _execute == null || !_execute.IsStatic && !_execute.IsAlive)
        return;
      _execute.Execute((T) parameter);
    }

    /// <summary>
    ///     Defines the method to be called when the command is invoked.
    /// </summary>
    /// <param name="parameter">This parameter will always be ignored.</param>
    public virtual void Execute(T parameter)
    {
      if (!CanExecute(parameter) || _execute == null || !_execute.IsStatic && !_execute.IsAlive)
        return;
      _execute.Execute(parameter);
    }
  }
}