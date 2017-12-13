#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "coladoblementeenlazada.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:

    ColaDoblementeEnlazada * cola = new ColaDoblementeEnlazada();
    int contador = 0;


    explicit MainWindow(QWidget *parent = 0);
    Ui::MainWindow *ui;
    ~MainWindow();

private slots:
    void on_pushButton_clicked();

    void on_pushButton_4_clicked();

    void on_pushButton_2_clicked();

    void on_pushButton_3_clicked();

private:

};

#endif // MAINWINDOW_H
