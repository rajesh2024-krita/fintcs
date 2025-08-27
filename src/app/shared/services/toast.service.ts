
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

export interface Toast {
  id: string;
  type: 'success' | 'error' | 'info' | 'warning';
  title?: string;
  message: string;
  duration?: number;
}

@Injectable({
  providedIn: 'root'
})
export class ToastService {
  private toastsSubject = new BehaviorSubject<Toast[]>([]);
  public toasts$ = this.toastsSubject.asObservable();

  private toasts: Toast[] = [];

  success(message: string, title?: string, duration = 5000): void {
    this.addToast('success', message, title, duration);
  }

  error(message: string, title?: string, duration = 8000): void {
    this.addToast('error', message, title, duration);
  }

  info(message: string, title?: string, duration = 5000): void {
    this.addToast('info', message, title, duration);
  }

  warning(message: string, title?: string, duration = 6000): void {
    this.addToast('warning', message, title, duration);
  }

  remove(id: string): void {
    this.toasts = this.toasts.filter(toast => toast.id !== id);
    this.toastsSubject.next(this.toasts);
  }

  clear(): void {
    this.toasts = [];
    this.toastsSubject.next(this.toasts);
  }

  private addToast(type: Toast['type'], message: string, title?: string, duration?: number): void {
    const toast: Toast = {
      id: this.generateId(),
      type,
      message,
      title,
      duration
    };

    this.toasts.push(toast);
    this.toastsSubject.next(this.toasts);

    if (duration && duration > 0) {
      setTimeout(() => {
        this.remove(toast.id);
      }, duration);
    }
  }

  private generateId(): string {
    return Math.random().toString(36).substr(2, 9);
  }
}
