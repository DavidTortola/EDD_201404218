#-------------------------------------------------
#
# Project created by QtCreator 2017-12-11T17:54:31
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = EDD_Practica1_201404218
TEMPLATE = app

# The following define makes your compiler emit warnings if you use
# any feature of Qt which has been marked as deprecated (the exact warnings
# depend on your compiler). Please consult the documentation of the
# deprecated API in order to know how to port your code away from it.
DEFINES += QT_DEPRECATED_WARNINGS

# You can also make your code fail to compile if you use deprecated APIs.
# In order to do so, uncomment the following line.
# You can also select to disable deprecated APIs only up to a certain version of Qt.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0


SOURCES += \
        main.cpp \
        mainwindow.cpp \
    coladoblementeenlazada.cpp \
    colasimple.cpp \
    listadoblementeenlazada.cpp \
    listadoblecircular.cpp \
    pila.cpp \
    listasimple.cpp \
    colasimpleaviones.cpp

HEADERS += \
        mainwindow.h \
    coladoblementeenlazada.h \
    colasimple.h \
    listadoblementeenlazada.h \
    listadoblecircular.h \
    pila.h \
    listasimple.h \
    colasimpleaviones.h

FORMS += \
        mainwindow.ui
